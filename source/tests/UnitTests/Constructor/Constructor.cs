// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

using Xunit;

namespace Michael.Types.UnitTests
{
    // Tests for the Integer (sequential day count) date store. The Trait
    // attribute marks these tests as belonging to the Integer store group so
    // test runners can filter by storage strategy.
    [Trait("Store", "Integer")]
    public class Constructor
    {
        // Factory configured to produce SequentialInteger-backed IntDate
        // instances. Using the factory keeps the tests independent of the
        // concrete IDateStore implementation while explicitly exercising the
        // integer-based storage strategy.
        private readonly DateFactory _factory = new DateFactory(DateFactory.DateStorage.SequentialInteger);

        // Ensure that constructing a date with explicit year/month/day does
        // not throw and returns a valid date instance. This test is primarily
        // a smoke test for construction.
        [Fact]
        public void Can_call_constructor_with_three_part_date()
        {
            var date = _factory.Create(1965, 11, 1);
        }

        // Verify the Day component is preserved when creating a date via the
        // factory with year/month/day parameters.
        [Fact]
        public void Can_call_constructor_with_three_part_date_and_get_back_correct_day()
        {
            var date = _factory.Create(1965, 11, 1);
            Assert.Equal(1, date.Day);
        }

        // Verify the Month component is preserved when creating a date via
        // the factory with year/month/day parameters.
        [Fact]
        public void Can_call_constructor_with_three_part_date_and_get_back_correct_month()
        {
            var date = _factory.Create(1965, 11, 1);
            Assert.Equal(11, date.Month);
        }

        // Verify the Year component is preserved when creating a date via
        // the factory with year/month/day parameters.
        [Fact]
        public void Can_call_constructor_with_three_part_date_and_get_back_correct_year()
        {
            var date = _factory.Create(1965, 11, 1);
            Assert.Equal(1, date.Year);
        }
    }
}
