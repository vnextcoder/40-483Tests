using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueingDemo
{
    class Program
    {
        static ConcurrentQueue<int> myqueue;
        static void Main(string[] args)
        {
            myqueue = new ConcurrentQueue<int>();

            Parallel.For(1, 500, i => myqueue.Enqueue(i));


            while (myqueue.Count > 0)
            {
                int ot;
                myqueue.TryDequeue(out ot);
                Console.WriteLine(ot);
            }


            Console.ReadLine();
        }
    }
}
