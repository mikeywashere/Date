using System;
using Xunit;
using Michael.Types;
using Shouldly;

namespace Michael.Types.UnitTests.TypeConversion
{
    public class TypeConversion
    {
        [Fact]
        public void Can_convert_to_DateTime()
        {
            var date = new Date(1965, 11, 1);
            var dateTime = (DateTime) date;
            dateTime.Year.ShouldBe(1965);
            dateTime.Month.ShouldBe(11);
            dateTime.Day.ShouldBe(1);
        }
    }
}
