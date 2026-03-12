// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

using Xunit;

namespace Michael.Types.UnitTests.OperatorOverload
{
    [Trait("Store", "Integer")]
    public class Plus
    {
        // Tests for the '+' operator overload on IntDate when using the
        // sequential-integer storage strategy. The Trait attribute marks
        // these tests as belonging to the Integer store group.

        // Factory configured to create SequentialInteger-backed IntDate
        // instances. Using the factory keeps the tests independent of the
        // concrete storage implementation while explicitly exercising the
        // integer-based behavior.
        private FlexDateFactory _factory = new FlexDateFactory(FlexDateFactory.DateStorage.SequentialInteger);

        // Verify that adding one day via the overloaded '+' operator returns
        // a new IntDate with the expected year/month/day components.
        [Fact]
        public void Can_call_operator_overload_plus_to_add_1_day()
        {
            var date = _factory.Create(1965, 11, 1);
            date = date + 1;

            Assert.Equal(1965, date.Year);
            Assert.Equal(11, date.Month);
            Assert.Equal(2, date.Day);
        }

        // Verify that adding ten days advances the date correctly.
        [Fact]
        public void Can_call_operator_overload_plus_to_add_10_day()
        {
            var date = _factory.Create(1965, 11, 1);
            date = date + 10;

            Assert.Equal(1965, date.Year);
            Assert.Equal(11, date.Month);
            Assert.Equal(11, date.Day);
        }

        // Verify that adding 100 days correctly rolls the date into the
        // next year and month as expected.
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