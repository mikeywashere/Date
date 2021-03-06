using System;
using Xunit;
using Michael.Types;
using Michael.Types;
using Shouldly;

namespace Michael.Types.DateUnitTests
{
    public class Constructor
    {
        [Fact]
        public void Can_call_constructor_with_three_part_date()
        {
            var date = new Date(1965,11,1);
        }

        [Fact]
        public void Can_call_constructor_with_three_part_date_and_get_back_correct_year()
        {
            var date = new Date(1965, 11, 1);
            date.Year.ShouldBe(1965);
        }

        [Fact]
        public void Can_call_constructor_with_three_part_date_and_get_back_correct_month()
        {
            var date = new Date(1965, 11, 1);
            date.Month.ShouldBe(11);
        }

        [Fact]
        public void Can_call_constructor_with_three_part_date_and_get_back_correct_day()
        {
            var date = new Date(1965, 11, 1);
            date.Day.ShouldBe(1);
        }
    }
}
