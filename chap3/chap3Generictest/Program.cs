using System;

namespace Generictest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(uint.MaxValue);
            Console.WriteLine(uint.MinValue);

            int myInt = new int();
            int myInt2 = new int();
            Console.WriteLine(myInt);
            Console.WriteLine(myInt2);

            Console.WriteLine("m2yhash".hash());

        }
    }
}
