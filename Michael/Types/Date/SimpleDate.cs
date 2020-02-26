// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

using System;

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

        public RawDate(DateTime dateTime) : this(dateTime.Year, dateTime.Month, dateTime.Day)
        { }

        public int Day { get; }
        public int Month { get; }
        public int Year { get; }
    }
}