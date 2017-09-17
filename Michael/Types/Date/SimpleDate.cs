using System;
using System.Collections.Generic;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Michael.Types
{
    public class RawDate : IDate
    {
        public RawDate(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        public RawDate(DateTime dateTime)
        {
            Year = dateTime.Year;
            Month = dateTime.Month;
            Day = dateTime.Day;
        }

        public int Year { get; }
        public int Month { get; }
        public int Day { get; }
    }
}
