using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            
// Execute the antecedent.
            //Task<DayOfWeek> taskA = Task.Run(() => DateTime.Today.DayOfWeek);

            //// Execute the continuation when the antecedent finishes.
            //Task continuation = taskA.ContinueWith(antecedent => Console.WriteLine("Today is {0}.", antecedent.Result));
            ////Console.ReadLine();
            //continuation.Wait();



            // Multiple Antecedants

            List<Task<int>> tasks = new List<Task<int>>();
            for (int ctr = 1; ctr <= 10; ctr++)
            {
                int baseValue = ctr;
                tasks.Add (


                    Task.Factory.StartNew((b) =>
                    {
                        int i = (int)b;
                        return i * i;
                    }, baseValue)

                );
                

            }
            //Continuation task when finishes will have all the Previous Results collated into single Array 
            //and can be looped/ processed together. 
            var continuation = Task.WhenAll(tasks);
            
            long sum = 0;
            continuation.Wait();
            if (continuation.Status == TaskStatus.RanToCompletion)
            {
                for (int ctr = 0; ctr <= continuation.Result.Length - 1; ctr++)
                {
                    Console.Write("{0} {1} ", continuation.Result[ctr],
                                  ctr == continuation.Result.Length - 1 ? "=" : "+");
                    sum += continuation.Result[ctr];
                }
                Console.WriteLine(sum);
            }
            Console.ReadLine();
        }
    }
}
