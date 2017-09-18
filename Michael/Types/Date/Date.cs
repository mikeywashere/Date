// ************************************************************
// Copyright Michael R. Schmidt 2017
// See License file at /license.txt
// ************************************************************

using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Michael.Types
{
    public class Date : IOperationalDate
    {
        #region Private Fields

        private readonly IDateStore _store;

        #endregion Private Fields

        #region Public Constructors

        public Date(IDateStore store)
        {
            _store = store;
        }

        public Date()
        {
            if (_store == null)
                _store = new IntegerDateStore();
        }

        public Date(int year, int month, int day) : this()
        {
            _store.Date = new RawDate(year, month, day);
        }

        public Date(DateTime dateTime) : this(dateTime.Year, dateTime.Month, dateTime.Day)
        {
        }

        public Date(IDateStore store, int year, int month, int day) : this(store)
        {
            _store.Date = new RawDate(year, month, day);
        }

        public Date(IDateStore store, DateTime dateTime) : this(store, dateTime.Year, dateTime.Month, dateTime.Day)
        {
        }


        #endregion Public Constructors

        #region Public Properties

        public IDateStore DateStore => _store;

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
            var newDateTime = dateTime.AddDays(daysToAdd);
            return new Date(newDateTime);
        }

        public Date SubtractDays(int daysToSubtract)
        {
            var dateTime = (DateTime)this;
            var newDateTime = dateTime.Subtract(TimeSpan.FromDays(daysToSubtract));
            return new Date(newDateTime);
        }

        public static bool operator <(Date left, IDate right)
        {
            return 
                left.Year < right.Year ||

                (left.Year == right.Year &&
                    left.Month < right.Month) ||

                (left.Year == right.Year &&
                    left.Month == right.Month &&
                    left.Day < right.Day);
        }

        public static bool operator >(Date left, IDate right)
        {
            return 
                left.Year > right.Year ||

                (left.Year == right.Year &&
                 left.Month > right.Month) ||

                (left.Year == right.Year &&
                 left.Month == right.Month &&
                 left.Day > right.Day);
        }


        public IEnumerable<IOperationalDate> Range(IDate startDate, IDate endDate)
        {
            var current = (Date)startDate;
            while (current < endDate)
            {
                yield return current;
                current = current + 1;
            }
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