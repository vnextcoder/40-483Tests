using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParentDependency
{
    class Program
    {
        
        public static void Main2()
        {
            //var parent = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("Outer task executing.");

            //    var child = Task.Factory.StartNew(() =>
            //    {
            //        Console.WriteLine("Nested task starting.");
            //        Thread.SpinWait(500000);
            //        Console.WriteLine("Nested task completing.");
            //    });

            //});

            //parent.Wait();
            //Console.WriteLine("Outer has completed.");



            //var outer = Task<int>.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("Outer task executing.");

            //    var nested = Task<int>.Factory.StartNew(() =>
            //    {
            //        Console.WriteLine("Nested task starting.");
            //        Thread.SpinWait(5000000);
            //        Console.WriteLine("Nested task completing.");
            //        return 42;
            //    });

            //    // Parent will wait for this detached child. 
            //    return nested.Result;
            //});

            //Console.WriteLine("Outer has returned {0}.", outer.Result);

            //var parent = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("Parent task executing.");
            //    var child = Task.Factory.StartNew(() =>
            //    {
            //        Console.WriteLine("Attached child starting.");
            //        Thread.SpinWait(5000000);
            //        Console.WriteLine("Attached child completing.");
            //    }, TaskCreationOptions.AttachedToParent);
            //});
            //parent.Wait();
            //Console.WriteLine("Parent has completed.");

            var parent2 = Task.Run(() =>
            {
                Console.WriteLine("Parent task executing.");
                var child = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Attached child starting.");
                    Thread.SpinWait(5000000);
                    Console.WriteLine("Attached child completing.");
                }, TaskCreationOptions.AttachedToParent);
            });
            parent2.Wait();
            Console.WriteLine("Parent has completed.");



        }
    }
}
