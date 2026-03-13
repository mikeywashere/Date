// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

using Xunit;

namespace Michael.Types.UnitTests.HumanReadable.Methods
{
    [Trait("Store", "HumanReadable")]
    public class AddDays_Test
    {
        // Factory configured to create BigEndian (human-readable) backed
        // IntDate instances. Tests in this class use the factory so they
        // remain independent of the concrete store implementation.
        private readonly FlexDateFactory _factory = new FlexDateFactory(FlexDateFactory.DateStorage.HumanReadable);

        // Verify adding one day produces the expected year/month/day values.
        // Note: this method currently does not have a [Fact] attribute in the
        // original test suite; if you want it executed by xUnit add [Fact].
        [Fact]
        public void Can_call_AddDays_to_add_1_day()
        {
            var date = _factory.Create(1965, 11, 1);
            date = date.AddDays(1);

            // Assert that the date components are correct after adding one day.
            Assert.Equal(1965, date.Year);
            Assert.Equal(11, date.Month);
            Assert.Equal(2, date.Day);
        }

        // Verify adding 10 days returns a new date with expected components.
        [Fact]
        public void Can_call_AddDays_to_add_10_days()
        {
            var date = _factory.Create(1965, 11, 1);
            var newDate = date.AddDays(10);

            // newDate is a separate instance returned by AddDays; validate
            // its component values.
            Assert.Equal(1965, newDate.Year);
            Assert.Equal(11, newDate.Month);
            Assert.Equal(11, newDate.Day);
        }

        // Verify adding 100 days correctly advances into the next year and
        // month. Like the first test, this method is not marked [Fact] so it
        // won't run unless the attribute is added.
        [Fact]
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