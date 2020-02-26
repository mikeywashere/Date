// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

// ReSharper disable once CheckNamespace
namespace Michael.Types
{
    public interface IDate
    {
        int Day { get; }
        int Month { get; }
        int Year { get; }
    }
}