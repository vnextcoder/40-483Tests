using System;

namespace Mainprogram {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
            Console.Write (typeof (string).Assembly.ImageRuntimeVersion);
        }
    }
}