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
        // Factory configured to produce BigEndian (human-readable) backed
        // IntDate instances. Using the factory keeps tests decoupled from
        // the concrete store implementation and makes intent explicit.
        private DateFactory _factory = new DateFactory(DateFactory.DateStorage.BigEndian);

        // Verify that an IntDate produced by the human-readable store can be
        // converted to a System.DateTime and preserves the correct
        // year/month/day components. The cast operator is expected to be
        // implemented on IntDate.
        [Fact]
        public void Can_convert_to_DateTime()
        {
            var date = _factory.Create(1965, 11, 1);

            // Convert IntDate to DateTime via explicit cast defined on IntDate.
            var dateTime = (DateTime)date;

            // Ensure each component round-trips correctly.
            Assert.Equal(1965, dateTime.Year);
            Assert.Equal(11, dateTime.Month);
            Assert.Equal(1, dateTime.Day);
        }
    }
}