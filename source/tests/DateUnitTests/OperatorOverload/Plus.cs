using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Michael.Types;
using Shouldly;

namespace Michael.Types.OperatorOverload.Plus.DateUnitTests
{
    class Plus
    {
        [Fact]
        public void Can_call_operator_overload_plus_to_add_1_day()
        {
            var date = new Date(1965, 11, 1);
            date = date + 1;
            date.Year.ShouldBe(1965);
            date.Month.ShouldBe(11);
            date.Day.ShouldBe(2);
        }
    }
}
