using System;

namespace IDisposableShape
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Shape shp=new Shape();
            shp=null;

            Console.WriteLine("Program ends here");
        }
    }
}
