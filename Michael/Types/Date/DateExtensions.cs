// ************************************************************
// Copyright Michael R. Schmidt 2020
// See License file at /license.txt
// ************************************************************

using System.Collections.Generic;

namespace Michael.Types
{
    public static class DateExt
    {
        public static IEnumerable<IOperationalDate> RangeTo(this IIntDate startDate, IIntDate endDate)
        {
            var current = (IntDate)startDate;
            while (current < endDate)
            {
                yield return current;
                current = current + 1;
            }
        }
    }
}