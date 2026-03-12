using Michael.Types;
using System;
using System.Linq;

namespace DateExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            FlexDateFactory factory = new FlexDateFactory(FlexDateFactory.DateStorage.HumanReadable);
            var startDate = factory.Create(1965, 11, 1);
            var endDate = factory.Create(DateTime.Now);
            var count = 0;
            var range = startDate.RangeTo(endDate);
            foreach (var day in range)
            {
                count++;
            }

            Console.WriteLine($"{Environment.NewLine}My count and the range count are {((range.Count() == count) ? string.Empty : "not ")}the same.");

            Console.WriteLine($"I am {count:#,#} days old.");
            Console.WriteLine($"Press any key...");
            Console.ReadKey();
        }
    }
}