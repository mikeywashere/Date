// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

using Xunit;

namespace Michael.Types.UnitTests.HumanReadable
{
    [Trait("Store", "HumanReadable")]
    public class Constructor
    {
        private readonly DateFactory _factory = new DateFactory(DateFactory.DateStorage.BigEndian);

        [Fact]
        public void Can_call_constructor_with_three_part_date()
        {
            var date = _factory.Create(1965, 11, 1);
        }

        [Fact]
        public void Can_call_constructor_with_three_part_date_and_get_back_correct_day()
        {
            var date = _factory.Create(1965, 11, 1);
            Assert.Equal(1, date.Day);
        }

        [Fact]
        public void Can_call_constructor_with_three_part_date_and_get_back_correct_month()
        {
            var date = _factory.Create(1965, 11, 1);
            Assert.Equal(11, date.Month);
        }

        [Fact]
        public void Can_call_constructor_with_three_part_date_and_get_back_correct_year()
        {
            var date = _factory.Create(1965, 11, 1);
            Assert.Equal(1, date.Year);
        }
    }
}