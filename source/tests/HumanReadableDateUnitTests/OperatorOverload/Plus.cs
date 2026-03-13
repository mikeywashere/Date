// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

using Xunit;

namespace Michael.Types.UnitTests.HumanReadable.OperatorOverload
{
    [Trait("Store", "HumanReadable")]
    public class Plus
    {
        // Tests for the '+' operator overload on IntDate when backed by the
        // BigEndian (human-readable) date store. The Trait attribute marks
        // these tests as belonging to the HumanReadable store grouping.

        // Factory configured to produce BigEndian-backed IntDate instances so
        // the tests exercise the human-readable storage behavior.
        private readonly FlexDateFactory _factory = new FlexDateFactory(FlexDateFactory.DateStorage.HumanReadable);

        // Verify that adding one day using the overloaded '+' operator returns
        // a new date with the expected year/month/day components.
        [Fact]
        public void Can_call_operator_overload_plus_to_add_1_day()
        {
            var date = _factory.Create(1965, 11, 1);
            date = date + 1;

            Assert.Equal(1965, date.Year);
            Assert.Equal(11, date.Month);
            Assert.Equal(2, date.Day);
        }

        // Verify that adding ten days advances the date correctly. This test
        // constructs an IntDate directly (without the factory) to ensure the
        // operator behaves consistently for direct IntDate instances.
        [Fact]
        public void Can_call_operator_overload_plus_to_add_10_day()
        {
            var date = _factory.Create(1965, 11, 1);
            date = date + 10;

            Assert.Equal(1965, date.Year);
            Assert.Equal(11, date.Month);
            Assert.Equal(11, date.Day);
        }

        // Verify that adding 100 days correctly rolls the date into the next
        // year and month as expected.
        [Fact]
        public void Can_call_operator_overload_plus_to_add_100_day()
        {
            var date = _factory.Create(1965, 11, 1);
            date = date + 100;

            Assert.Equal(1966, date.Year);
            Assert.Equal(2, date.Month);
            Assert.Equal(9, date.Day);
        }
    }
}