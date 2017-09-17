// ************************************************************
// Copyright Michael R. Schmidt 2017
// See License file at /license.txt
// ************************************************************

// ReSharper disable once CheckNamespace
namespace Michael.Types
{
    public class HumanReadableDateStore : IDateStore<int>, IDateStore
    {
        #region Private Fields

        private int _date;

        #endregion Private Fields

        #region Public Constructors

        public HumanReadableDateStore()
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public IDate Date
        {
            get => new RawDate(ToYear(), ToMonth(), ToDay());
            set
            {
                _date = value.Year * 10000 + value.Month * 100 + value.Day;
            }
        }

        public int Raw => _date;

        #endregion Public Properties

        #region Private Methods

        private int ToDay()
        {
            return _date - (ToYear() * 10000 + ToMonth() * 100);
        }

        private int ToMonth()
        {
            return _date / 100 - (ToYear() * 100);
        }

        private int ToYear()
        {
            return _date / 10000;
        }

        #endregion Private Methods

        object IDateStore.Raw => Raw;
    }
}