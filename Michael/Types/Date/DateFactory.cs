using System;
using System.Collections.Generic;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Michael.Types
{
    public class DateFactory
    {
        public enum DateStorage
        {
            Integer,
            HumanReadable
        }

        public static DateStorage Storage
        {
            get;
            private set;
        }

        public DateFactory()
        {
            Storage = DateStorage.Integer;
        }

        public DateFactory(DateStorage store)
        {
            Storage = store;
        }

        public void Configure(DateStorage store)
        {
            Storage = store;
        }

        private IDateStore GetStorage()
        {
            switch (Storage)
            {
                case (DateStorage.Integer):
                    return new IntegerDateStore();
                case (DateStorage.HumanReadable):
                    return new HumanReadableDateStore();
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return null;
        }

        public Date Create()
        {
            return new Date(GetStorage());
        }

        public Date Create(int year, int month, int day)
        {
            return new Date(GetStorage(), year, month, day);
        }

        public Date Create(DateTime dateTime)
        {
            return Create(dateTime.Year, dateTime.Month, dateTime.Day);
        }

    }
}
