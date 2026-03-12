// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

using Xunit;

namespace Michael.Types.UnitTests.HumanReadable.OperatorOverload
{
    [Trait("Store", "HumanReadable")]
    public class Plus
    {
        private readonly DateFactory _factory = new DateFactory(DateFactory.DateStorage.BigEndian);

        [Fact]
        public void Can_call_operator_overload_plus_to_add_1_day()
        {
            var date = _factory.Create(1965, 11, 1);
            date = date + 1;
            Assert.Equal(1965, date.Year);
            Assert.Equal(11, date.Month);
            Assert.Equal(2, date.Day);
        }

        [Fact]
        public void Can_call_operator_overload_plus_to_add_10_day()
        {
            var date = new IntDate(1965, 11, 1);
            date = date + 10;
            Assert.Equal(1965, date.Year);
            Assert.Equal(11, date.Month);
            Assert.Equal(11, date.Day);
        }

        [Fact]
        public void Can_call_operator_overload_plus_to_add_100_day()
        {
            var date = new IntDate(1965, 11, 1);
            date = date + 100;
            Assert.Equal(1966, date.Year);
            Assert.Equal(2, date.Month);
            Assert.Equal(9, date.Day);
        }
    }
}