using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cancellationtokendemo
{
    class Aggregationexceptiondemo
    {

        public static void Main()
        {
            try
            {
                var exceptions = new ConcurrentQueue<Exception>();

                Parallel.For(0L, 500L, i =>
                {
                    try
                    {
                        if (i % 100 == 0)
                            throw new TimeoutException("i = " + i.ToString());

                        Console.WriteLine(i + "\n");
                    }
                    catch (Exception e)
                    {
                        exceptions.Enqueue(e);
                    }
                });

                if (exceptions.Count > 0)
                    throw new AggregateException(exceptions);
            }

            catch (AggregateException exception)
            {
                foreach (Exception ex in exception.InnerExceptions)
                    Console.WriteLine(ex.Message);
            }
        }
    }
}

