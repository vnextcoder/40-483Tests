using System;

namespace Delegatessample {
    class Program {

        delegate double MySumFunction (int param);
        MySumFunction mySum;

        private double sum (int param) {
            return param * param;
        }

        private double sum2 (int param) {
            return Math.Pow (param, param);
        }
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
            Console.WriteLine ("i am also hello");

            Program p = new Program ();
            p.mySum = new MySumFunction (p.sum);
            Console.WriteLine (p.mySum (4));

            p.mySum = p.sum2;
            Console.WriteLine (p.mySum (4));

            p.mySum = (pt) => {
                Console.WriteLine ("using Lambda");
                return Math.Pow (pt, pt);
            };

            Console.WriteLine (p.mySum (4));
            p.mySum = delegate (int param) {
                Console.WriteLine ("using delegate function twice the input");
                return 2 * param;
            };


            Console.WriteLine (p.mySum (4));

            Console.WriteLine ("Hello World" + System.Threading.Thread.CurrentThread.ManagedThreadId);
            System.Threading.Thread thread = new System.Threading.Thread (
                delegate () { Console.WriteLine ("Hello World" + System.Threading.Thread.CurrentThread.ManagedThreadId); }
            );
            thread.Start ();

            thread.Join();

            Action note;
                note = () => Console.WriteLine("Hi");
            note();


            Action<string> not2e;
                not2e = (message) => Console.WriteLine(message);
            not2e("Hello there from Action method");


            Func<float,float> square= (x) => x*x;
            Func<float,float> square2= (x) => {
                
                Console.WriteLine("x is " + x);
                return x*x;};
            Console.WriteLine(square(10));

            Console.WriteLine(square2(12));
        }

    }
}