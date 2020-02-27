// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

namespace Michael.Types
{
    public interface IDateStore<out T>
    {
        IIntDate IntDate { get; set; }

        T Raw { get; }
    }

    public interface IDateStore
    {
        IIntDate IntDate { get; set; }

        object Raw { get; }
    }
}