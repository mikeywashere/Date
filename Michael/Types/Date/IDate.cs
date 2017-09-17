// ************************************************************
// Copyright Michael R. Schmidt 2017
// See License file at /license.txt
// ************************************************************

// ReSharper disable once CheckNamespace
namespace Michael.Types
{
    public interface IDate
    {
        #region Public Properties

        int Day { get; }
        int Month { get; }
        int Year { get; }

        #endregion Public Properties
    }
}