// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

using Shouldly;
using System;
using Xunit;

namespace Michael.Types.UnitTests.TypeConversion
{
    [Trait("Store", "Integer")]
    public class TypeConversion
    {
        private DateFactory _factory = new DateFactory(DateFactory.DateStorage.Integer);

        [Fact]
        public void Can_convert_to_DateTime()
        {
            var date = new Date(1965, 11, 1);
            var dateTime = (DateTime)date;
            dateTime.Year.ShouldBe(1965);
            dateTime.Month.ShouldBe(11);
            dateTime.Day.ShouldBe(1);
        }
    }
}