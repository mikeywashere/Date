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
    public class BigEndianDateStore : IDateStore<int>, IDateStore
    {
        // MonthMask (100) and YearMask (10000) are used to split the packed
        // integer into year/month/day components using integer division and
        // remainder arithmetic. The encoding is:
        //    packed = Year * YearMask + Month * MonthMask + Day
        // which corresponds to YYYYMMDD when YearMask=10000 and MonthMask=100.
        private const int MonthMask = 100;
        private const int YearMask = 10000;

        // Backing field that holds the packed YYYYMMDD value.
        private int _date;

        /// <summary>
        /// Gets or sets the date as an IIntDate. The getter unpacks the stored
        /// integer into year, month and day. The setter packs the provided
        /// components back into the single integer representation.
        /// </summary>
        public IIntDate IntDate
        {
            get =>
                // Year: integer division by 10000 (YYYY)
                // Month: divide by 100 to remove day, then subtract year*100
                // Day: remainder after dividing by 100
                new RawDate(
                    _date / YearMask,
                    _date / MonthMask - _date / YearMask * MonthMask,
                    _date - (_date / MonthMask) * MonthMask);
            set => _date = value.Year * YearMask + value.Month * MonthMask + value.Day;
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