// ************************************************************
// Copyright Michael R. Schmidt 2017
// See License file at /license.txt
// ************************************************************

using Shouldly;
using Xunit;

// ReSharper disable once CheckNamespace
namespace Michael.Types.UnitTests.HumanReadable.Methods
{
    [Trait("Store", "HumanReadable")]
    public class AddDays
    {
        #region Public Constructors

        private DateFactory _factory = new DateFactory(DateFactory.DateStorage.HumanReadable);

        #endregion Public Constructors

        #region Public Methods

        public void Can_call_AddDays_to_add_1_day()
        {
            var date = _factory.Create(1965, 11, 1);
            date = date.AddDays(1);
            date.Year.ShouldBe(1965);
            date.Month.ShouldBe(11);
            date.Day.ShouldBe(2);
        }

        [Fact]
        public void Can_call_AddDays_to_add_10_days()
        {
            var date = _factory.Create(1965, 11, 1);
            var newDate = date.AddDays(10);
            newDate.Year.ShouldBe(1965);
            newDate.Month.ShouldBe(11);
            newDate.Day.ShouldBe(11);
        }

        public void Can_call_AddDays_to_add_100_days()
        {
            var date = _factory.Create(1965, 11, 1);
            date = date.AddDays(100);
            date.Year.ShouldBe(1966);
            date.Month.ShouldBe(2);
            date.Day.ShouldBe(9);
        }

        #endregion Public Methods
    }
}