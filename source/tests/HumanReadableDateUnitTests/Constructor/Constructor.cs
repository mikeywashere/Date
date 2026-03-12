// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

using Xunit;

namespace Michael.Types.UnitTests.HumanReadable
{
    // Tests for the BigEndian (human-readable) date store when constructing
    // dates using the factory. The Trait attribute marks these tests as
    // belonging to the HumanReadable store group so test runners can filter
    // by storage strategy.
    [Trait("Store", "HumanReadable")]
    public class Constructor
    {
        // Factory configured to produce BigEndian (year/month/day) backed
        // IntDate instances for the tests in this class.
        private readonly DateFactory _factory = new DateFactory(DateFactory.DateStorage.BigEndian);

        // Verify that the factory constructor call with explicit year/month/day
        // does not throw and returns a date instance. The test does not assert
        // further behaviour — its purpose is simply to exercise construction.
        [Fact]
        public void Can_call_constructor_with_three_part_date()
        {
            var date = _factory.Create(1965, 11, 1);
        }

        // Ensure the Day component round-trips correctly when creating a date
        // with year/month/day parameters.
        [Fact]
        public void Can_call_constructor_with_three_part_date_and_get_back_correct_day()
        {
            var date = _factory.Create(1965, 11, 1);
            Assert.Equal(1, date.Day);
        }

        // Ensure the Month component round-trips correctly when creating a
        // date with year/month/day parameters.
        [Fact]
        public void Can_call_constructor_with_three_part_date_and_get_back_correct_month()
        {
            var date = _factory.Create(1965, 11, 1);
            Assert.Equal(11, date.Month);
        }

        // Ensure the Year component round-trips correctly when creating a
        // date with year/month/day parameters.
        [Fact]
        public void Can_call_constructor_with_three_part_date_and_get_back_correct_year()
        {
            var date = _factory.Create(1965, 11, 1);
            Assert.Equal(1, date.Year);
        }
    }
}
