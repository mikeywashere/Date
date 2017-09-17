using System;
using System.Collections.Generic;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Michael.Types
{
    public class HumanReadableDateStore : IDateStore<int>, IDateStore
    {
        private int _date;

        public HumanReadableDateStore()
        {
        }
 
        private int ToYear()
        {
            return _date / 10000;
        }

        private int ToMonth()
        {
            return _date / 100 - (ToYear() * 100);
        }

        private int ToDay()
        {
            return _date - (ToYear() * 10000 + ToMonth() * 100);
        }

        public IDate Date
        {
            get => new RawDate(ToYear(), ToMonth(), ToDay());
            set
            {
                _date = value.Year * 10000 + value.Month * 100 + value.Day;
            }
        }

        object IDateStore.Raw => Raw;

        public int Raw => _date;
    }
}
