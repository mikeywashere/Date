// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

using Xunit;

namespace Michael.Types.UnitTests.HumanReadable.Methods
{
    [Trait("Store", "HumanReadable")]
    public class AddDays
    {
        private readonly DateFactory _factory = new DateFactory(DateFactory.DateStorage.BigEndian);

        public void Can_call_AddDays_to_add_1_day()
        {
            var date = _factory.Create(1965, 11, 1);
            date = date.AddDays(1);
            Assert.Equal(1965, date.Year);
            Assert.Equal(11, date.Month);
            Assert.Equal(2, date.Day);
        }

        [Fact]
        public void Can_call_AddDays_to_add_10_days()
        {
            var date = _factory.Create(1965, 11, 1);
            var newDate = date.AddDays(10);
            Assert.Equal(1965, newDate.Year);
            Assert.Equal(11, newDate.Month);
            Assert.Equal(11, newDate.Day);
        }

        public void Can_call_AddDays_to_add_100_days()
        {
            var date = _factory.Create(1965, 11, 1);
            date = date.AddDays(100);
            Assert.Equal(1966, date.Year);
            Assert.Equal(2, date.Month);
            Assert.Equal(9, date.Day);
        }
    }
}