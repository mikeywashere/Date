// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

using System;

namespace Michael.Types
{
    public class IntegerDateStore : IDateStore<int>, IDateStore
    {
        /// <summary>
        /// The epoch from which the integer day count is measured. By default
        /// this is <see cref="DateTime.MinValue"/> but a different start date
        /// can be supplied via the constructor.
        /// </summary>
        private readonly DateTime _startOn;

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
            _startOn = DateTime.MinValue;
        }

        /// <summary>
        /// Create an IntegerDateStore that measures days from a custom epoch.
        /// </summary>
        /// <param name="startOn">The DateTime used as day 0 for this store.</param>
        public IntegerDateStore(DateTime startOn)
        {
            _startOn = startOn;
        }

        /// <summary>
        /// Convenience ctor that accepts year/month/day and uses that date as
        /// the epoch (startOn).
        /// </summary>
        public IntegerDateStore(int year, int month, int day) : this(new DateTime(year, month, day))
        {
        }

        /// <summary>
        /// Exposes the stored date as an <see cref="IIntDate"/> (year, month,
        /// day). The getter reconstructs a Date from the day-count and the
        /// configured epoch. The setter converts the provided year/month/day
        /// into the day-count relative to the epoch.
        /// </summary>
        public IIntDate IntDate
        {
            get => new RawDate(_startOn.AddDays(_days));
            set
            {
                // Build a DateTime from the provided components and compute
                // the integer day difference to store.
                var dateTime = new DateTime(value.Year, value.Month, value.Day);
                _days = Convert.ToInt32(dateTime.Subtract(_startOn).TotalDays);
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
    }
}