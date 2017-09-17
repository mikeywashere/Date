// ************************************************************
// Copyright Michael R. Schmidt 2017
// See License file at /license.txt
// ************************************************************

using System;

// ReSharper disable once CheckNamespace
namespace Michael.Types
{
    public class Date : IDate
    {
        #region Private Fields

        private readonly IDateStore _store;

        #endregion Private Fields

        #region Public Constructors

        public Date() : this(DefaultStore ?? new IntegerDateStore())
        {
        }

        public Date(IDateStore store)
        {
            _store = store;
        }

        public Date(int year, int month, int day) : this()
        {
            _store.Date = new RawDate(year, month, day);
        }

        public Date(DateTime dateTime) : this(dateTime.Year, dateTime.Month, dateTime.Day)
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public static IDateStore DefaultStore
        {
            get;
            set;
        }

        public int Day => _store.Date.Day;

        public int Month => _store.Date.Month;

        public int Year => _store.Date.Year;

        #endregion Public Properties

        #region Public Methods

        public static explicit operator DateTime(Date date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }

        public static Date operator +(Date date, int days)
        {
            return date.AddDays(days);
        }

        public Date AddDays(int daysToAdd)
        {
            var dateTime = (DateTime)this;
            dateTime = dateTime.AddDays(daysToAdd);
            return new Date(dateTime);
        }

        #endregion Public Methods

        #region Private Methods

        private static DateTime ToDate(int days)
        {
            return DateTime.MinValue.AddDays(days);
        }

        private static int ToInt(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);
            return Convert.ToInt32(date.Subtract(DateTime.MinValue).TotalDays);
        }

        private static (int Year, int Month, int Day) ToYearMonthDay(int days)
        {
            var dateTime = ToDate(days);
            return (dateTime.Year, dateTime.Month, dateTime.Day);
        }

        #endregion Private Methods
    }
}