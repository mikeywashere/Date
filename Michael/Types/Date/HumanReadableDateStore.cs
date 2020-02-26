// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

namespace Michael.Types
{
    public class HumanReadableDateStore : IDateStore<int>, IDateStore
    {
        private const int MonthMask = 100;
        private const int YearMask = 10000;

        private int _date;

        public IDate Date
        {
            get =>
                new RawDate(
                    _date / YearMask,
                    _date / MonthMask - _date / YearMask * MonthMask,
                    _date - (_date / MonthMask) * MonthMask);
            set => _date = value.Year * YearMask + value.Month * MonthMask + value.Day;
        }

        public int Raw => _date;

        object IDateStore.Raw => Raw;
    }
}