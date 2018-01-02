using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionCost
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();

            Console.WriteLine("Start");
            int n = 10000;
            // Yeild O/P from exception
            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 1; i <= n; i++)
            {
                try
                {
                    SomeThingBadHappenedThrowEx();
                }
                catch (Exception)
                {

                }
            }
            stopwatch.Stop();
            Console.WriteLine(n + " Exceptions checks to decide failure took " + stopwatch.ElapsedMilliseconds.ToString() + " ms");

            // Test return codes
            stopwatch.Reset();
            stopwatch.Start();
            bool retcode;
            for (int i = 1; i <= n; i++)
            {
                retcode = SomeThingBadHappenedReturnFalse();
                if (!retcode)
                {

                }
            }
            stopwatch.Stop();
            Console.WriteLine(n + " Return codes checks to decide failure took " + stopwatch.ElapsedMilliseconds.ToString() + " ms");
            Console.ReadKey();
        }

        static void SomeThingBadHappenedThrowEx()
        {
            throw new Exception("Failed");
        }

        static bool SomeThingBadHappenedReturnFalse()
        {
            return false;
        }
    }
}
