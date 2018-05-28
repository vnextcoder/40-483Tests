using System;
using System.Diagnostics;

namespace Exceptionone {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");

            try {
                Console.WriteLine ("hello");
            } catch (FormatException ex) {
                Console.WriteLine ("FormatException");
            } catch (SystemException ex) {
                Console.WriteLine ("SystemException");
            } catch (Exception ex) {
                Console.WriteLine ("Exception");
            }

            try {
                int i = 0;
                Console.WriteLine (10 / i);
            } catch {

                Console.WriteLine ("all excpetions");
            }
            Debug.Assert(10<100);
        }
    }
}