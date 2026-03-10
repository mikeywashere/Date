using System;

namespace Michael.Types
{
    public class DateFactory
    {
        public enum DateStorage
        {
            SequentialInteger,
            BigEndian
        }

        private DateStorage Storage { get; set; }

        public static DateStorage SequentialInteger
        {
            get;
            private set;
        }

        public DateFactory()
        {
            Storage = DateStorage.SequentialInteger;
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
                case (DateStorage.SequentialInteger):
                    return new IntegerDateStore();

                case (DateStorage.BigEndian):
                    return new BigEndianDateStore();

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public IntDate Create()
        {
            return new IntDate(GetStorage());
        }

        public IntDate Create(IDateStore storage, int year, int month, int day)
        {
            return new IntDate(GetStorage(), year, month, day);
        }

        public IntDate Create(int year, int month, int day)
        {
            return Create(GetStorage(), year, month, day);
        }

        public IntDate Create(IDateStore storage, DateTime dateTime)
        {
            return Create(storage, dateTime.Year, dateTime.Month, dateTime.Day);
        }

        public IntDate Create(DateTime dateTime)
        {
            return Create(GetStorage(), dateTime.Year, dateTime.Month, dateTime.Day);
        }
    }
}