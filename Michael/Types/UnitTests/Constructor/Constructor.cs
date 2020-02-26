// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

using Shouldly;
using Xunit;

namespace Michael.Types.UnitTests.Constructor
{
    [Trait("Store", "Integer")]
    public class Constructor
    {
        private DateFactory _factory = new DateFactory(DateFactory.DateStorage.Integer);

        [Fact]
        public void Can_call_constructor_with_three_part_date()
        {
            var date = _factory.Create(1965, 11, 1);
        }

        [Fact]
        public void Can_call_constructor_with_three_part_date_and_get_back_correct_day()
        {
            var date = _factory.Create(1965, 11, 1);
            date.Day.ShouldBe(1);
        }

        [Fact]
        public void Can_call_constructor_with_three_part_date_and_get_back_correct_month()
        {
            var date = _factory.Create(1965, 11, 1);
            date.Month.ShouldBe(11);
        }

        [Fact]
        public void Can_call_constructor_with_three_part_date_and_get_back_correct_year()
        {
            var date = _factory.Create(1965, 11, 1);
            date.Year.ShouldBe(1965);
        }
    }
}