using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnostics
{
    public class PerformanceCounterExample
    {
        public static void CallExample()
        {
            Console.WriteLine("Press escape key to stop");
            using (PerformanceCounter pc = new PerformanceCounter("Memory", "Available Bytes"))
            {
                string text = "Available memory: ";
                Console.Write(text);
                do
                {
                    while (!Console.KeyAvailable)
                    {
                        Console.Write(pc.RawValue);
                        Console.SetCursorPosition(text.Length, Console.CursorTop);
                    }
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            }
        

        }

        public static void CallExample2()
        {
            if (CreatePerformanceCounters())
            {
                Console.WriteLine("Created performance counters"); Console.WriteLine("Please restart application");
                Console.ReadKey();
                return;
            }
            var totalOperationsCounter = new PerformanceCounter(
            "MyCategory",
            "# operations executed",
            "", false);
            var operationsPerSecondCounter = new PerformanceCounter(
            "MyCategory",
            "# operations / sec",
            "",
            false);

            totalOperationsCounter.Increment();
            operationsPerSecondCounter.Increment();

        }

        private static bool CreatePerformanceCounters()
        {
            if (!PerformanceCounterCategory.Exists("MyCategory"))
            {
                CounterCreationDataCollection counters = new CounterCreationDataCollection
                {
                    new CounterCreationData(
                        "# operations executed", 
                        "Total number of operations executed",
                        PerformanceCounterType.NumberOfItems32),
                    new CounterCreationData(
                        "# operations / sec",
                        "Number of operations executed per second",
                        PerformanceCounterType.RateOfCountsPerSecond32)
                };

                PerformanceCounterCategory.Create(
                        "MyCategory",
                        "Sample category for Codeproject", 
                        counters);
                return true;
            }
            return false;
        }
    }


}

