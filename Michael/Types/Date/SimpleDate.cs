// ************************************************************
// Copyright Michael R. Schmidt 2017
// See License file at /license.txt
// ************************************************************

using System;

// ReSharper disable once CheckNamespace
namespace Michael.Types
{
    public class RawDate : IDate
    {
        #region Public Constructors

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

        #endregion Public Constructors

        #region Public Properties

        public int Day { get; }
        public int Month { get; }
        public int Year { get; }

        #endregion Public Properties
    }
}