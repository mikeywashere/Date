using System;
using Xunit;
using Michael.Types;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace Michael.Types.UnitTests.HumanReadable.Methods
{
    public class AddDays
    {
        public AddDays()
        {
            Date.DefaultStore = new HumanReadableDateStore();
        }

        [Fact]
        public void Can_call_AddDays_to_add_1_day()
        {
            var date = new Date(1965, 11, 1);
            date = date.AddDays(1);
            date.Year.ShouldBe(1965);
            date.Month.ShouldBe(11);
            date.Day.ShouldBe(2);
        }

        [Fact]
        public void Can_call_AddDays_to_add_10_days()
        {
            var date = new Date(1965, 11, 10);
            date = date.AddDays(1);
            date.Year.ShouldBe(1965);
            date.Month.ShouldBe(11);
            date.Day.ShouldBe(11);
        }

        public void Can_call_AddDays_to_add_100_days()
        {
            var date = new Date(1965, 11, 100);
            date = date.AddDays(100);
            date.Year.ShouldBe(1966);
            date.Month.ShouldBe(2);
            date.Day.ShouldBe(9);
        }


    }
}
