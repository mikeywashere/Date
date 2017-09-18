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

        private DateFactory _factory = new DateFactory(DateFactory.DateStorage.HumanReadable);

        #endregion Public Constructors

        #region Public Methods

        [Fact]
        public void Can_convert_to_DateTime()
        {
            var date = _factory.Create(1965, 11, 1);
            var dateTime = (DateTime)date;
            dateTime.Year.ShouldBe(1965);
            dateTime.Month.ShouldBe(11);
            dateTime.Day.ShouldBe(1);
        }

        #endregion Public Methods
    }
}