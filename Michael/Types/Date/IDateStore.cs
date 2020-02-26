// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

namespace Michael.Types
{
    public interface IDateStore<out T>
    {
        IDate Date { get; set; }

        T Raw { get; }
    }

    public interface IDateStore
    {
        IDate Date { get; set; }

        object Raw { get; }
    }
}