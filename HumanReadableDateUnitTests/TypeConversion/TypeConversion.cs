// ************************************************************
// Copyright Michael R. Schmidt 2017
// See License file at /license.txt
// ************************************************************

using Shouldly;
using System;
using Xunit;

// ReSharper disable once CheckNamespace
namespace Michael.Types.UnitTests.HumanReadable.TypeConversion
{
    [Trait("Store", "HumanReadable")]
    public class TypeConversion
    {
        #region Public Constructors

        public TypeConversion()
        {
            Date.DefaultStore = new HumanReadableDateStore();
        }

        #endregion Public Constructors

        #region Public Methods

        [Fact]
        public void Can_convert_to_DateTime()
        {
            var date = new Date(1965, 11, 1);
            var dateTime = (DateTime)date;
            dateTime.Year.ShouldBe(1965);
            dateTime.Month.ShouldBe(11);
            dateTime.Day.ShouldBe(1);
        }

        #endregion Public Methods
    }
}