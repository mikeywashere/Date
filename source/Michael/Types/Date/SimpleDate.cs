// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

namespace Michael.Types
{
    /// <summary>
    /// Simple immutable representation of a date as year, month and day
    /// components. Implements <see cref="ISimpleDate"/> so it can be used
    /// by storage implementations and other date types in the library.
    /// </summary>
    public class SimpleDate : ISimpleDate
    {
        /// <summary>
        /// Create a SimpleDate from explicit year, month and day components.
        /// </summary>
        /// <param name="year">The year component (e.g. 1965).</param>
        /// <param name="month">The month component (1-12).</param>
        /// <param name="day">The day component (1-31 depending on month/year).</param>
        public SimpleDate(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        /// <summary>
        /// Create a SimpleDate from a <see cref="DateTime"/>, copying the
        /// Year/Month/Day components.
        /// </summary>
        /// <param name="dateTime">The source DateTime value.</param>
        public SimpleDate(DateTime dateTime) : this(dateTime.Year, dateTime.Month, dateTime.Day)
        { }

        /// <summary>
        /// Create a SimpleDate from a <see cref="DateOnly"/>, copying the
        /// Year/Month/Day components.
        /// </summary>
        /// <param name="dateOnly"></param>
        public SimpleDate(DateOnly dateOnly) : this(dateOnly.Year, dateOnly.Month, dateOnly.Day)
        { }

        /// <summary>
        /// Day component of the date.
        /// </summary>
        public int Day { get; }

        /// <summary>
        /// Month component of the date (1-12).
        /// </summary>
        public int Month { get; }

        /// <summary>
        /// Year component of the date (e.g. 1965).
        /// </summary>
        public int Year { get; }
    }
}