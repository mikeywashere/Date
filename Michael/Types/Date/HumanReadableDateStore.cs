// ************************************************************
// Copyright Michael R. Schmidt 2017
// See License file at /license.txt
// ************************************************************

// ReSharper disable once CheckNamespace
namespace Michael.Types
{
    public class HumanReadableDateStore : IDateStore<int>, IDateStore
    {
        private const int MonthMask = 100;
        private const int YearMask = 10000;

        #region Private Fields

        private int _date;

        #endregion Private Fields

        #region Public Constructors

        #endregion Public Constructors

        #region Public Properties

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

        #endregion Public Properties

        object IDateStore.Raw => Raw;
    }
}