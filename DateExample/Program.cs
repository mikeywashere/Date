using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Michael.Types;

namespace DateExample
{
    class Program
    {
        static void Main(string[] args)
        {
            DateFactory factory = new DateFactory(DateFactory.DateStorage.HumanReadable);
            var startDate = factory.Create(1965, 11, 1);
            var endDate = factory.Create(DateTime.Now);
            var count = 0;
            foreach (var day in startDate.Range(startDate, endDate))
            {
                count++;
            }
            Console.WriteLine($"I am {count} days old.");
            Console.ReadKey();
        }
    }
}
