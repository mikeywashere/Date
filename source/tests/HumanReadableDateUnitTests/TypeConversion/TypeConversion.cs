// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

using System;
using Xunit;

namespace Michael.Types.UnitTests.HumanReadable.TypeConversion
{
    [Trait("Store", "HumanReadable")]
    public class TypeConversion
    {
        private DateFactory _factory = new DateFactory(DateFactory.DateStorage.BigEndian);

        [Fact]
        public void Can_convert_to_DateTime()
        {
            var date = _factory.Create(1965, 11, 1);
            var dateTime = (DateTime)date;
            Assert.Equal(1965, dateTime.Year);
            Assert.Equal(11, dateTime.Month);
            Assert.Equal(1, dateTime.Day);
        }
    }
}