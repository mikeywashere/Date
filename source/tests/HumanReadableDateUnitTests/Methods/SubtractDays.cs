// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

using Xunit;

namespace Michael.Types.UnitTests.HumanReadable.Methods
{
    [Trait("Store", "HumanReadable")]
    public class SubtractDays
    {
        // Factory configured to create BigEndian (human-readable) backed
        // IntDate instances. Tests use the factory to remain implementation-
        // independent and to explicitly exercise the human-readable store.
        private readonly FlexDateFactory _factory = new FlexDateFactory(FlexDateFactory.DateStorage.HumanReadable);

        // Verify subtracting a single day yields the expected year/month/day
        // components. This method is not marked with [Fact] in the original
        // suite, so it will not run unless the attribute is added.
        [Fact]
        public void Can_call_SubtractDays_to_subtract_1_day()
        {
            var date = _factory.Create(1965, 11, 2);
            date = date.SubtractDays(1);

            // Assert that the date components are correct after subtraction.
            Assert.Equal(1965, date.Year);
            Assert.Equal(11, date.Month);
            Assert.Equal(1, date.Day);
        }

        // Verify subtracting 10 days correctly moves the date back by ten
        // days. This test is decorated with [Fact] so it will be executed by
        // xUnit.
        [Fact]
        public void Can_call_SubtractDays_to_subtract_10_days()
        {
            var date = _factory.Create(1965, 11, 11);
            date = date.SubtractDays(10);

            Assert.Equal(1965, date.Year);
            Assert.Equal(11, date.Month);
            Assert.Equal(1, date.Day);
        }

        // Verify subtracting 100 days moves the date into the previous year
        // and month as expected. Like the first method, this one is not
        // decorated with [Fact] and therefore won't run unless the attribute
        // is added.
        [Fact]
        public void Can_call_SubtractDays_to_subtract_100_days()
        {
            var date = _factory.Create(1966, 2, 9);
            date = date.SubtractDays(100);

            Assert.Equal(1965, date.Year);
            Assert.Equal(11, date.Month);
            Assert.Equal(1, date.Day);
        }
    }
}