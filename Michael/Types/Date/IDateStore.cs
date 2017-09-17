using System;

// ReSharper disable once CheckNamespace
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
