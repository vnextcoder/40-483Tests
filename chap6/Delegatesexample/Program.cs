using System;

namespace Delegatesexample {

    class Program {
        delegate int area ();
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");

            area TheFunction;
            
            TheFunction = dome;
            TheFunction();
            TheFunction = dome2;
            TheFunction();
            
            Action a1=dome3 ;
            Action a2= dome4;
            Action a3=a1+a2;

            a1();
            a2();
            Console.WriteLine("calling all 2 ");
            a3();
            

        }
        public static void dome3 () {
            Console.WriteLine ("hello from action functiondome3");
            
        }

public static void dome4 () {
            Console.WriteLine ("hello from action function dome4");
            
        }

        public static int dome () {
            Console.WriteLine ("hello from delegate function");
            return 0;
        }

public static int dome2 () {
            Console.WriteLine ("hello from delegate function number 2");
            return 0;
        }
        
    }
}