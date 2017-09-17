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
    public class SubtractDays
    {
        #region Public Constructors

        private readonly DateFactory _factory = new DateFactory(DateFactory.DateStorage.HumanReadable);

        #endregion Public Constructors

        #region Public Methods

        public void Can_call_SubtractDays_to_subtract_1_day()
        {
            var date = _factory.Create(1965, 11, 2);
            date = date.SubtractDays(1);
            date.Year.ShouldBe(1965);
            date.Month.ShouldBe(11);
            date.Day.ShouldBe(1);
        }

        [Fact]
        public void Can_call_SubtractDays_to_subtract_10_days()
        {
            var date = _factory.Create(1965, 11, 11);
            date = date.SubtractDays(10);
            date.Year.ShouldBe(1965);
            date.Month.ShouldBe(11);
            date.Day.ShouldBe(1);
        }

        public void Can_call_SubtractDays_to_subtract_100_days()
        {
            var date = _factory.Create(1966, 2, 9);
            date = date.SubtractDays(100);
            date.Year.ShouldBe(1965);
            date.Month.ShouldBe(11);
            date.Day.ShouldBe(1);
        }

        #endregion Public Methods
    }
}