// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

using System;

namespace Michael.Types
{
    /// <summary>
    /// Simple immutable representation of a date as year, month and day
    /// components. Implements <see cref="IIntDate"/> so it can be used
    /// by storage implementations and other date types in the library.
    /// </summary>
    public class RawDate : IIntDate
    {
        /// <summary>
        /// Create a RawDate from explicit year, month and day components.
        /// </summary>
        /// <param name="year">The year component (e.g. 1965).</param>
        /// <param name="month">The month component (1-12).</param>
        /// <param name="day">The day component (1-31 depending on month/year).</param>
        public RawDate(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        /// <summary>
        /// Create a RawDate from a <see cref="DateTime"/>, copying the
        /// Year/Month/Day components.
        /// </summary>
        /// <param name="dateTime">The source DateTime value.</param>
        public RawDate(DateTime dateTime) : this(dateTime.Year, dateTime.Month, dateTime.Day)
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