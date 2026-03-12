// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

using System.Collections.Generic;

namespace Michael.Types
{
    public static class DateExt
    {
        /// <summary>
        /// Extension helpers for working with IIntDate/IOperationalDate types.
        /// </summary>
        public static IEnumerable<IOperationalDate> RangeTo(this IIntDate startDate, IIntDate endDate)
        {
            // Cast the start interface to the concrete IntDate implementation so
            // we can use the comparison and arithmetic operators defined on IntDate.
            var current = (IntDate)startDate;

            // Iterate from the start date up to (but not including) the end date,
            // yielding each date as an IOperationalDate. The caller can enumerate
            // the returned sequence lazily.
            while (current < endDate)
            {
                yield return current;

                // Advance to the next day using the overloaded + operator.
                current += 1;
            }
        }
    }
}