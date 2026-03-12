// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

using Xunit;

namespace Michael.Types.UnitTests.Methods
{
    [Trait("Store", "Integer")]
    public class AddDays
    {
        // Tests for AddDays when using the integer (sequential day count)
        // storage strategy. The Trait attribute marks these tests so they
        // can be filtered by storage type when running the test suite.

        // Factory configured to create SequentialInteger-backed IntDate
        // instances. Using the factory keeps tests independent of the
        // concrete storage implementation.
        private FlexDateFactory _factory = new FlexDateFactory(FlexDateFactory.DateStorage.SequentialInteger);

        // Verify adding one day produces the expected year/month/day values.
        [Fact]
        public void Can_call_AddDays_to_add_1_day()
        {
            var date = _factory.Create(1965, 11, 1);
            date = date.AddDays(1);

            // Validate each component after adding one day.
            Assert.Equal(1965, date.Year);
            Assert.Equal(11, date.Month);
            Assert.Equal(2, date.Day);
        }

        // Verify adding ten days returns a new date with expected values.
        [Fact]
        public void Can_call_AddDays_to_add_10_days()
        {
            var date = _factory.Create(1965, 11, 1);
            date = date.AddDays(10);

            Assert.Equal(1965, date.Year);
            Assert.Equal(11, date.Month);
            Assert.Equal(11, date.Day);
        }

        // Verify adding 100 days correctly advances into the next year and
        // month. This method is not marked with [Fact] in the original
        // suite so it will not run unless the attribute is added.
        public void Can_call_AddDays_to_add_100_days()
        {
            var date = _factory.Create(1965, 11, 1);
            date = date.AddDays(100);

            Assert.Equal(1966, date.Year);
            Assert.Equal(2, date.Month);
            Assert.Equal(9, date.Day);
        }
    }
}