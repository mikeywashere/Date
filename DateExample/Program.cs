using Michael.Types;
using System;
using System.Linq;

namespace DateExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DateFactory factory = new DateFactory(DateFactory.DateStorage.HumanReadable);
            var startDate = factory.Create(1965, 11, 1);
            var endDate = factory.Create(DateTime.Now);
            var count = 0;
            var range = startDate.RangeTo(endDate);
            foreach (var day in range)
            {
                count++;
            }

            Console.WriteLine($"My count and the range count are {((range.Count() == count) ? string.Empty : "not ")}the same.");

            Console.WriteLine($"I am {count:#,#} days old.");
            Console.ReadKey();
        }
    }
}