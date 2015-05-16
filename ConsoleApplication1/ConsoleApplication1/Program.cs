using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
//            Console.WriteLine("Hello World from Git HUB master");
//Console.WriteLine("should have french as well ");
//            Console.WriteLine("I am german now");
//            Console.WriteLine("Lots of TypeCode written");
            DisplayTimerProperties();
            Console.ReadLine();
        }

        private static void DisplayTimerProperties()
        {
            if (Stopwatch.IsHighResolution)
            {
                Console.WriteLine("Operations timed using the system's high resolution performance counter");
            }
            else
            {
                Console.WriteLine("Operations timed using DateTime Class");
            }
            long frequency = Stopwatch.Frequency;
            Console.WriteLine("    Timer frequency in ticks per second = {0}", frequency);
            long nanosecPerTick = (1000L * 1000L * 1000L) / frequency;
            Console.WriteLine("    Timer is accurate within {0} nanoseconds", nanosecPerTick);
        }
    }
}
