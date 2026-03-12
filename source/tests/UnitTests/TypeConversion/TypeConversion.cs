// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

using System;
using Xunit;

namespace Michael.Types.UnitTests.TypeConversion
{
    [Trait("Store", "Integer")]
    public class TypeConversion
    {
        private DateFactory _factory = new DateFactory(DateFactory.DateStorage.SequentialInteger);

        [Fact]
        public void Can_convert_to_DateTime()
        {
            var date = new IntDate(1965, 11, 1);
            var dateTime = (DateTime)date;
            Assert.Equal(1965, dateTime.Year);
            Assert.Equal(11, dateTime.Month);
            Assert.Equal(1, dateTime.Day);
        }
    }
}