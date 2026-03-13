// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

namespace Michael.Types
{
    /// <summary>
    /// Big-endian (human-readable) storage for an IntDate.
    ///
    /// The store encodes a date as a single integer in the form YYYYMMDD
    /// using simple decimal-place arithmetic. Example: 19651101 encodes
    /// 1965-11-01.
    ///
    /// This class implements both the generic IDateStore<int> and the
    /// non-generic IDateStore interfaces.
    /// </summary>
    public class HumanReadableDateStore : IDateStore<int>, IDateStore
    {
        /// <summary>
        /// Month multiplier used when packing/unpacking the decimal-style
        /// YYYYMMDD integer representation. A value of 100 isolates the
        /// month when dividing by this factor.
        /// </summary>
        private const int MonthMask = 100;

        /// <summary>
        /// Year multiplier used when packing/unpacking the decimal-style
        /// YYYYMMDD integer representation. A value of 10000 shifts the
        /// year into the high-order decimal places (YYYY0000).
        /// </summary>
        private const int YearMask = 10000;

        /// <summary>
        /// Backing field that holds the packed YYYYMMDD integer value.
        /// </summary>
        private int _date;

        /// <summary>
        /// Gets or sets the date as an IIntDate. The getter unpacks the stored
        /// integer into year, month and day. The setter packs the provided
        /// components back into the single integer representation.
        /// </summary>
        public ISimpleDate SimpleDate
        {
            get =>
                // Year: integer division by 10000 (YYYY)
                // Month: divide by 100 to remove day, then subtract year*100
                // Day: remainder after dividing by 100
                new SimpleDate(
                    _date / YearMask,
                    _date / MonthMask - _date / YearMask * MonthMask,
                    _date - (_date / MonthMask) * MonthMask);
            set => _date = value.Year * YearMask + value.Month * MonthMask + value.Day;
        }

        /// <summary>
        /// Converts the packed integer to a <see cref="DateOnly"/> instance.
        /// </summary>
        /// <returns>A DateOnly representing the stored date.</returns>
        public DateOnly ToDateOnly()
        {
            return new DateOnly(_date / YearMask, _date / MonthMask - _date / YearMask * MonthMask, _date - (_date / MonthMask) * MonthMask);
        }

        /// <summary>
        /// Converts the packed integer to a <see cref="DateTime"/> at midnight.
        /// </summary>
        /// <returns>A DateTime representing the stored date at 00:00:00.</returns>
        public DateTime ToDateTime()
        {
            return new DateTime(_date / YearMask, _date / MonthMask - _date / YearMask * MonthMask, _date - (_date / MonthMask) * MonthMask);
        }

        /// <summary>
        /// Converts the packed integer to a <see cref="DateTime"/> using the
        /// supplied <see cref="TimeOnly"/> for the time component.
        /// </summary>
        /// <param name="time">TimeOfDay to combine with the stored date.</param>
        /// <returns>A DateTime representing the stored date with the provided time.</returns>
        public DateTime ToDateTime(TimeOnly time)
        {
            return new DateTime(ToDateOnly(), time);
        }

        /// <summary>
        /// Returns the raw packed integer representation (YYYYMMDD).
        /// </summary>
        public int Raw => _date;

        // Explicit interface implementation for the non-generic IDateStore.Raw
        // property so the same packed value can be accessed as object.
        object IDateStore.Raw => Raw;
    }
}