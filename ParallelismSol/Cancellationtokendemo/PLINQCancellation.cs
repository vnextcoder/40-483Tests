using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cancellationtokendemo
{
    class PLINQCancellation
    {
        public static void GetPrimeNumbers()
        {

            IEnumerable<int> million = Enumerable.Range(3, 1000000);
            Stopwatch sw = Stopwatch.StartNew();
            var cancelSource = new CancellationTokenSource();
            var primeNumberQuery =
              from n in million.AsParallel().WithCancellation(cancelSource.Token)
              where Enumerable.Range(2, (int)Math.Sqrt(n)).All(i => n % i > 0)
              select n;

            new Thread(() =>
            {
                Thread.Sleep(100);      // Cancel query after
                cancelSource.Cancel();   // 100 milliseconds.
            }
             ).Start();
            try
            {



                // Start query running:
                int[] primes = primeNumberQuery.ToArray();
                Array.Sort<int>(primes);
                sw.Stop();
                Console.WriteLine(sw.Elapsed.ToString());
                Console.ReadLine();

                //foreach (var i in primes)
                //{
                //    Console.WriteLine(i);
                //}
                // We'll never get here because the other thread will cancel us.
            }
            catch (OperationCanceledException oe)
            {
                Console.WriteLine("Query canceled" + oe.ToString());
            }
            catch (AggregateException ae)
            {
                ae.Handle(ex =>
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                });
            }


        }
    }
}
