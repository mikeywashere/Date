using System;
using System.Collections.Generic;
using System.Text;

namespace Michael.Types
{
    public interface IOperationalDate : IDate
    {
        Date AddDays(int days);

        Date SubtractDays(int days);
    }
}
