// ************************************************************
// Copyright Michael R. Schmidt 2017
// See License file at /license.txt
// ************************************************************

// ReSharper disable once CheckNamespace
namespace Michael.Types
{
    public interface IDateStore<out T>
    {
        #region Public Properties

        IDate Date { get; set; }

        T Raw { get; }

        #endregion Public Properties
    }

    public interface IDateStore
    {
        #region Public Properties

        IDate Date { get; set; }

        object Raw { get; }

        #endregion Public Properties
    }
}