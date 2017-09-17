// ************************************************************
// Copyright Michael R. Schmidt 2017
// See License file at /license.txt
// ************************************************************

using Shouldly;
using Xunit;

// ReSharper disable once CheckNamespace
namespace Michael.Types.UnitTests.HumanReadable
{
    [Trait("Store", "HumanReadable")]
    public class Constructor
    {
        #region Public Constructors

        public Constructor()
        {
            Date.DefaultStore = new HumanReadableDateStore();
        }

        #endregion Public Constructors

        #region Public Methods

        [Fact]
        public void Can_call_constructor_with_three_part_date()
        {
            var date = new Date(1965, 11, 1);
        }

        [Fact]
        public void Can_call_constructor_with_three_part_date_and_get_back_correct_day()
        {
            var date = new Date(1965, 11, 1);
            date.Day.ShouldBe(1);
        }

        [Fact]
        public void Can_call_constructor_with_three_part_date_and_get_back_correct_month()
        {
            var date = new Date(1965, 11, 1);
            date.Month.ShouldBe(11);
        }

        [Fact]
        public void Can_call_constructor_with_three_part_date_and_get_back_correct_year()
        {
            var date = new Date(1965, 11, 1);
            date.Year.ShouldBe(1965);
        }

        #endregion Public Methods
    }
}