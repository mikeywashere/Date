// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

using System;
using System.Collections.Generic;

namespace Michael.Types
{
    public class IntDate : IOperationalDate
    {
        private readonly IDateStore _store;

        public IntDate(IDateStore store)
        {
            _store = store;
        }

        public IntDate()
        {
            if (_store == null)
                _store = new IntegerDateStore();
        }

        public IntDate(int year, int month, int day) : this()
        {
            _store.IntDate = new RawDate(year, month, day);
        }

        public IntDate(DateTime dateTime) : this(dateTime.Year, dateTime.Month, dateTime.Day)
        {
        }

        public IntDate(IDateStore store, int year, int month, int day) : this(store)
        {
            _store.IntDate = new RawDate(year, month, day);
        }

        public IntDate(IDateStore store, DateTime dateTime) : this(store, dateTime.Year, dateTime.Month, dateTime.Day)
        {
        }

        public IDateStore DateStore => _store;

        public int Day => _store.IntDate.Day;

        public int Month => _store.IntDate.Month;

        public int Year => _store.IntDate.Year;

        public static explicit operator DateTime(IntDate date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }

        public static IntDate operator +(IntDate date, int days)
        {
            return date.AddDays(days);
        }

        public IntDate AddDays(int daysToAdd)
        {
            var dateTime = (DateTime)this;
            var newDateTime = dateTime.AddDays(daysToAdd);
            return new IntDate(newDateTime);
        }

        public IntDate SubtractDays(int daysToSubtract)
        {
            var dateTime = (DateTime)this;
            var newDateTime = dateTime.Subtract(TimeSpan.FromDays(daysToSubtract));
            return new IntDate(newDateTime);
        }

        public static bool operator <(IntDate left, IIntDate right)
        {
            return
                left.Year < right.Year ||

                (left.Year == right.Year &&
                    left.Month < right.Month) ||

                (left.Year == right.Year &&
                    left.Month == right.Month &&
                    left.Day < right.Day);
        }

        public static bool operator >(IntDate left, IIntDate right)
        {
            return
                left.Year > right.Year ||

                (left.Year == right.Year &&
                 left.Month > right.Month) ||

                (left.Year == right.Year &&
                 left.Month == right.Month &&
                 left.Day > right.Day);
        }

        public IEnumerable<IOperationalDate> Range(IIntDate startDate, IIntDate endDate)
        {
            var current = (IntDate)startDate;
            while (current < endDate)
            {
                yield return current;
                current = current + 1;
            }
        }

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
    }
}