// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

namespace Michael.Types
{
    /// <summary>
    /// Represents an integer-backed date value used by the FlexDate types.
    /// IntDate adapts an <see cref="IDateStore"/> for storage and provides
    /// basic date arithmetic and comparison operators.
    /// </summary>
    public class SequentialIntegerDate : IOperationalDate
    {
        // Underlying storage implementation for this date.
        private readonly IDateStore _store;

        /// <summary>
        /// Initializes a new instance of <see cref="SequentialIntegerDate"/> that uses the
        /// provided <see cref="IDateStore"/> for backing storage.
        /// </summary>
        public SequentialIntegerDate(IDateStore store)
        {
            _store = store;
        }

        /// <summary>
        /// Default constructor. If no store was provided, a default
        /// <see cref="IntegerDateStore"/> is used.
        /// </summary>
        public SequentialIntegerDate()
        {
            if (_store == null)
                _store = new IntegerDateStore();
        }

        /// <summary>
        /// Constructs an IntDate from explicit year, month and day values.
        /// </summary>
        public SequentialIntegerDate(int year, int month, int day) : this()
        {
            _store.SimpleDate = new SimpleDate(year, month, day);
        }

        /// <summary>
        /// Constructs an IntDate from a <see cref="DateTime"/>.
        /// </summary>
        public SequentialIntegerDate(DateTime dateTime) : this(dateTime.Year, dateTime.Month, dateTime.Day)
        {
        }

        /// <summary>
        /// Constructs an IntDate using the supplied store and explicit y/m/d.
        /// </summary>
        public SequentialIntegerDate(IDateStore store, int year, int month, int day) : this(store)
        {
            _store = _store ?? throw new ArgumentNullException(nameof(store));

            _store.SimpleDate = new SimpleDate(year, month, day);
        }

        /// <summary>
        /// Constructs an IntDate using the supplied store and a DateTime.
        /// </summary>
        public SequentialIntegerDate(IDateStore store, DateTime dateTime) : this(store, dateTime.Year, dateTime.Month, dateTime.Day)
        {
        }

        /// <summary>
        /// Exposes the underlying <see cref="IDateStore"/> used by this instance.
        /// </summary>
        public IDateStore DateStore => _store;

        /// <summary>
        /// Day component of the stored date.
        /// </summary>
        public int Day => _store.SimpleDate.Day;

        /// <summary>
        /// Month component of the stored date.
        /// </summary>
        public int Month => _store.SimpleDate.Month;

        /// <summary>
        /// Year component of the stored date.
        /// </summary>
        public int Year => _store.SimpleDate.Year;

        /// <summary>
        /// Explicit conversion to <see cref="DateTime"/>.
        /// </summary>
        public static explicit operator DateTime(SequentialIntegerDate date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }

        /// <summary>
        /// Adds days to an <see cref="SequentialIntegerDate"/> using the + operator.
        /// </summary>
        public static SequentialIntegerDate operator +(SequentialIntegerDate date, int days)
        {
            return date.AddDays(days);
        }

        /// <summary>
        /// Returns a new IntDate that is the specified number of days after
        /// the current instance.
        /// </summary>
        public SequentialIntegerDate AddDays(int daysToAdd)
        {
            var dateTime = (DateTime)this;
            var newDateTime = dateTime.AddDays(daysToAdd);
            return new SequentialIntegerDate(newDateTime);
        }

        /// <summary>
        /// Returns a new IntDate that is the specified number of days before
        /// the current instance.
        /// </summary>
        public SequentialIntegerDate SubtractDays(int daysToSubtract)
        {
            var dateTime = (DateTime)this;
            var newDateTime = dateTime.Subtract(TimeSpan.FromDays(daysToSubtract));
            return new SequentialIntegerDate(newDateTime);
        }

        /// <summary>
        /// Compares two dates for "less than" semantics.
        /// </summary>
        public static bool operator <(SequentialIntegerDate left, ISimpleDate right)
        {
            return
                left.Year < right.Year ||

                (left.Year == right.Year &&
                    left.Month < right.Month) ||

                (left.Year == right.Year &&
                    left.Month == right.Month &&
                    left.Day < right.Day);
        }

        /// <summary>
        /// Compares two dates for "greater than" semantics.
        /// </summary>
        public static bool operator >(SequentialIntegerDate left, ISimpleDate right)
        {
            return
                left.Year > right.Year ||

                (left.Year == right.Year &&
                 left.Month > right.Month) ||

                (left.Year == right.Year &&
                 left.Month == right.Month &&
                 left.Day > right.Day);
        }

#if NET10_0
        /// <summary>
        /// Add a day to the date using ++ operator
        /// </summary>
        public void operator ++() => this.AddDays(1);

        /// <summary>
        /// Subtract a dato from the date using -- operator
        /// </summary>
        public void operator --() => this.SubtractDays(1);
#endif

        /// <summary>
        /// Returns an enumerable of dates from startDate (inclusive) up to
        /// but not including endDate. Note: this implementation uses an
        /// iterator (yield) and therefore returns a reference-type
        /// enumerator which may allocate on the heap when enumerated.
        /// </summary>
        public IEnumerable<IOperationalDate> Range(ISimpleDate startDate, ISimpleDate endDate)
        {
            var current = (SequentialIntegerDate)startDate;
            while (current < endDate)
            {
                yield return current;
                current += 1;
            }
        }

        /// <summary>
        /// Converts an integer day count (days since DateTime.MinValue)
        /// into a DateTime value.
        /// </summary>
        private static DateTime ToDate(int days)
        {
            return DateTime.MinValue.AddDays(days);
        }

        /// <summary>
        /// Converts year/month/day values to an integer day count since
        /// DateTime.MinValue.
        /// </summary>
        private static int ToInt(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);
            return Convert.ToInt32(date.Subtract(DateTime.MinValue).TotalDays);
        }

        /// <summary>
        /// Converts an integer day count into a tuple of (Year, Month, Day).
        /// </summary>
        private static (int Year, int Month, int Day) ToYearMonthDay(int days)
        {
            var dateTime = ToDate(days);
            return (dateTime.Year, dateTime.Month, dateTime.Day);
        }
    }
}