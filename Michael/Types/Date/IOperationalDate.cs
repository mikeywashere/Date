using System.Collections.Generic;

namespace Michael.Types
{
    public interface IOperationalDate : IDate
    {
        Date AddDays(int days);

        Date SubtractDays(int days);

        IEnumerable<IOperationalDate> Range(IDate startDate, IDate endDate);
    }
}