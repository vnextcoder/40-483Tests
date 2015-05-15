using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasksdemo
{
    class Program
    {
        static void Main(string[] args)
        {

            //Thread.CurrentThread.Name = "Main";

            //// Create a task and supply a user delegate by using a lambda expression. 
            //Task taskA = new Task(() => Console.WriteLine("Hello from taskA."));
            //// Start the task.

            //// Create a task and supply a user delegate by using a lambda expression. 
            //Task taskB = new Task(() => Console.WriteLine("Hello from taskB."));
            //// Start the task.
            



            //// Output a message from the calling thread.
            //Console.WriteLine("Hello from thread '{0}'.",
            //                  Thread.CurrentThread.Name);


            //Task taskC = Task.Run(() => Console.WriteLine("i am started in Task C "));

            //taskB.Start(); taskA.Start();


            //Task.WaitAny(taskA, taskB,taskC);
            //Console.ReadLine();

            Task<Double>[] taskArray = { Task<Double>.Factory.StartNew(() => DoComputation(1.0)),
                                     Task<Double>.Factory.StartNew(() => DoComputation(100.0)), 
                                     Task<Double>.Factory.StartNew(() => DoComputation(1000.0)) };

            //Task<double>[] taskArray = {
            //                     Task<double>.Factory.StartNew(()=> doSQRT(400))
            //                     };

            var results = new Double[taskArray.Length];
            double sum = 0;
            for (int i = 0; i < taskArray.Length; i++)
            {
                results[i] = taskArray[i].Result;
                Console.Write("{0:N1} {1}", results[i],
                              i == taskArray.Length - 1 ? "= " : "+ ");
                sum += results[i];
            }
            Console.WriteLine("{0:N1}", sum);

            Console.ReadLine();


        }
        private static Double DoComputation(Double start)
        {
            Double sum = 0;
            for (var value = start; value <= start + 10; value += 1)
                sum += value;

            return sum;
        }
        private static double doSQRT(double data)
        {
            return  Math.Sqrt(data);
        }



    }
}
