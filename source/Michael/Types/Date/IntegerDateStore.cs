// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

namespace Michael.Types
{
    /// <summary>
    /// Integer-backed implementation of <see cref="IDateStore"/> that
    /// represents a date as the number of days since a configurable epoch
    /// (<see cref="_startOn"/>). Uses <see cref="DateOnly"/> for the
    /// epoch to avoid time-of-day semantics.
    /// </summary>
    public class IntegerDateStore : IDateStore<int>, IDateStore
    {
        /// <summary>
        /// The epoch from which the integer day count is measured. By default
        /// this is <see cref="DateTime.MinValue"/> but a different start date
        /// can be supplied via the constructor.
        /// </summary>
        private readonly DateOnly _startOn;

        /// <summary>
        /// The number of days since <see cref="_startOn"/> representing the
        /// stored date. This compact integer form is useful for arithmetic and
        /// efficient storage.
        /// </summary>
        private int _days;

        /// <summary>
        /// Create an IntegerDateStore that measures days from DateTime.MinValue.
        /// </summary>
        public IntegerDateStore()
        {
            _startOn = DateOnly.MinValue;
        }

        /// <summary>
        /// Create an IntegerDateStore that measures days from a custom epoch.
        /// </summary>
        /// <param name="startOn">The DateTime used as day 0 for this store.</param>
        public IntegerDateStore(DateOnly startOn)
        {
            _startOn = startOn;
        }

        /// <summary>
        /// Create an IntegerDateStore that measures days from a custom epoch.
        /// The provided <see cref="DateTime"/> is converted to a <see cref="DateOnly"/>
        /// and used as the epoch (day 0) for this store.
        /// </summary>
        /// <param name="startOn">The DateTime used as day 0 for this store.</param>
        public IntegerDateStore(DateTime startOn) : this(DateOnly.FromDateTime(startOn))
        {
        }


        /// <summary>
        /// Convenience ctor that accepts year/month/day and uses that date as
        /// the epoch (startOn).
        /// </summary>
        public IntegerDateStore(int year, int month, int day) : this(new DateTime(year, month, day))
        {
        }

        /// <summary>
        /// Exposes the stored date as an <see cref="ISimpleDate"/> (year, month,
        /// day). The getter reconstructs a Date from the day-count and the
        /// configured epoch. The setter converts the provided year/month/day
        /// into the day-count relative to the epoch.
        /// </summary>
        public ISimpleDate SimpleDate
        {
            get => new SimpleDate(_startOn.AddDays(_days));
            set
            {
                // this is the date we are going to set to, converted to a DateTime for easier arithmetic
                var setDateTime = new DateTime(value.Year, value.Month, value.Day);
                // we need the startOn time as a DateTime to do the subtraction, so we convert it to DateTime at midnight
                var startOnDateTime = _startOn.ToDateTime(new TimeOnly(0));
                // let's find how many days there are between the startOn and the date we want to set, and store that as the raw integer value
                var timeDistance = setDateTime.Subtract(startOnDateTime);
                // set the raw integer value to the total number of days between the startOn and the date we want to set
                _days = Convert.ToInt32(timeDistance.TotalDays);
            }
        }

        /// <summary>
        /// Returns the raw integer representation (number of days since epoch).
        /// </summary>
        public int Raw => _days;

        /// <summary>
        /// Explicit implementation for the non-generic IDateStore returning the
        /// same raw value boxed as an object.
        /// </summary>
        object IDateStore.Raw => Raw;

        public DateOnly ToDateOnly()
        {
            throw new NotImplementedException();
        }

        public DateTime ToDateTime()
        {
            throw new NotImplementedException();
        }

        public DateTime ToDateTime(TimeOnly time)
        {
            throw new NotImplementedException();
        }
    }
}