// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

using Shouldly;
using Xunit;

namespace Michael.Types.UnitTests.OperatorOverload
{
    [Trait("Store", "Integer")]
    public class Plus
    {
        private DateFactory _factory = new DateFactory(DateFactory.DateStorage.SequentialInteger);

        [Fact]
        public void Can_call_operator_overload_plus_to_add_1_day()
        {
            var date = _factory.Create(1965, 11, 1);
            date = date + 1;
            date.Year.ShouldBe(1965);
            date.Month.ShouldBe(11);
            date.Day.ShouldBe(2);
        }

        [Fact]
        public void Can_call_operator_overload_plus_to_add_10_day()
        {
            var date = _factory.Create(1965, 11, 1);
            date = date + 10;
            date.Year.ShouldBe(1965);
            date.Month.ShouldBe(11);
            date.Day.ShouldBe(11);
        }

        [Fact]
        public void Can_call_operator_overload_plus_to_add_100_day()
        {
            var date = _factory.Create(1965, 11, 1);
            date = date + 100;
            date.Year.ShouldBe(1966);
            date.Month.ShouldBe(2);
            date.Day.ShouldBe(9);
        }
    }
}