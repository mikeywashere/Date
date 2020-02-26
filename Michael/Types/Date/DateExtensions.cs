// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Michael.Types
{
    public static class DateExt
    {
        public static IEnumerable<IOperationalDate> RangeTo(this IDate startDate, IDate endDate)
        {
            var current = (Date)startDate;
            while (current < endDate)
            {
                yield return current;
                current = current + 1;
            }
        }
    }
}