// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

using Xunit;

namespace Michael.Types.UnitTests.HumanReadable.Methods
{
    [Trait("Store", "HumanReadable")]
    public class SubtractDays
    {
        private readonly DateFactory _factory = new DateFactory(DateFactory.DateStorage.BigEndian);

        public void Can_call_SubtractDays_to_subtract_1_day()
        {
            var date = _factory.Create(1965, 11, 2);
            date = date.SubtractDays(1);
            Assert.Equal(1965, date.Year);
            Assert.Equal(11, date.Month);
            Assert.Equal(1, date.Day);
        }

        [Fact]
        public void Can_call_SubtractDays_to_subtract_10_days()
        {
            var date = _factory.Create(1965, 11, 11);
            date = date.SubtractDays(10);
            Assert.Equal(1965, date.Year);
            Assert.Equal(11, date.Month);
            Assert.Equal(1, date.Day);
        }

        public void Can_call_SubtractDays_to_subtract_100_days()
        {
            var date = _factory.Create(1966, 2, 9);
            date = date.SubtractDays(100);
            Assert.Equal(1965, date.Year);
            Assert.Equal(11, date.Month);
            Assert.Equal(1, date.Day);
        }
    }
}