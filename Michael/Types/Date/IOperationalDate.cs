using System.Collections.Generic;

namespace Michael.Types
{
    public interface IOperationalDate : IIntDate
    {
        IntDate AddDays(int days);

        IntDate SubtractDays(int days);

        IEnumerable<IOperationalDate> Range(IIntDate startDate, IIntDate endDate);
    }
}