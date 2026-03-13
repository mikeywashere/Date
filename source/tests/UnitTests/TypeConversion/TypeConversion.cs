// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

using System;
using Xunit;

namespace Michael.Types.UnitTests.TypeConversion
{
    [Trait("Store", "Integer")]
    public class TypeConversion_SequentialInteger_Test
    {
        // Tests for conversion between the integer-backed IntDate and
        // System.DateTime. The Trait attribute marks these tests as
        // belonging to the Integer storage strategy so test runners can
        // filter by storage type.

        // Factory configured to create SequentialInteger-backed IntDate
        // instances. The factory is not used in this specific test which
        // constructs an IntDate directly, but is kept to mirror other test
        // classes and for potential future tests.
        private FlexDateFactory _factory = new FlexDateFactory(FlexDateFactory.DateStorage.SequentialInteger);

        // Verify that an IntDate can be explicitly converted to DateTime and
        // that the resulting DateTime preserves the year/month/day
        // components of the original date.
        [Fact]
        public void Can_convert_to_DateTime()
        {
            // Construct an IntDate directly with year/month/day components.
            var date = _factory.Create(1965, 11, 1);

            // Use the explicit cast operator defined on IntDate to obtain a
            // System.DateTime instance.
            var dateTime = (DateTime)date;

            // Validate that each component round-trips correctly.
            Assert.Equal(1965, dateTime.Year);
            Assert.Equal(11, dateTime.Month);
            Assert.Equal(1, dateTime.Day);
        }
    }

    [Trait("Store", "HumanReadable")]
    public class TypeConversion_HumanReadable_Test
    {
        // Tests for conversion between the human-readable date and
        // System.DateTime. The Trait attribute marks these tests as
        // belonging to the Integer storage strategy so test runners can
        // filter by storage type.

        // Factory configured to create SequentialInteger-backed IntDate
        // instances. The factory is not used in this specific test which
        // constructs an IntDate directly, but is kept to mirror other test
        // classes and for potential future tests.
        private FlexDateFactory _factory = new FlexDateFactory(FlexDateFactory.DateStorage.HumanReadable);

        // Verify that an IntDate can be explicitly converted to DateTime and
        // that the resulting DateTime preserves the year/month/day
        // components of the original date.
        [Fact]
        public void Can_convert_to_DateTime()
        {
            // Construct an IntDate directly with year/month/day components.
            var date = _factory.Create(1965, 11, 1);

            // Use the explicit cast operator defined on IntDate to obtain a
            // System.DateTime instance.
            var dateTime = (DateTime)date;

            // Validate that each component round-trips correctly.
            Assert.Equal(1965, dateTime.Year);
            Assert.Equal(11, dateTime.Month);
            Assert.Equal(1, dateTime.Day);
        }
    }
}