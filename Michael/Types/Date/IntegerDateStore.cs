// ************************************************************
// Copyright Michael R. Schmidt 2017
// See License file at /license.txt
// ************************************************************

using System;

// ReSharper disable once CheckNamespace
namespace Michael.Types
{
    public class IntegerDateStore : IDateStore<int>, IDateStore
    {
        #region Private Fields

        private readonly DateTime _startOn;
        private int _days;

        #endregion Private Fields

        #region Public Constructors

        public IntegerDateStore()
        {
            _startOn = DateTime.MinValue;
        }

        public IntegerDateStore(DateTime startOn)
        {
            _startOn = startOn;
        }

        public IntegerDateStore(int year, int month, int day) : this(new DateTime(year, month, day))
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public IDate Date
        {
            get => new RawDate(_startOn.AddDays(_days));
            set
            {
                var dateTime = new DateTime(value.Year, value.Month, value.Day);
                _days = Convert.ToInt32(dateTime.Subtract(_startOn).TotalDays);
            }
        }

        public int Raw => _days;
        object IDateStore.Raw => Raw;

        #endregion Public Properties
    }
}