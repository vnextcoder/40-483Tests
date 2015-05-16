using System;
using Extensions;
namespace ExtensionMethod
{
    class Program
    {
        static void doWork()
        {
            // TODO:	
            int i = 591;
            Console.WriteLine(i.Negate());


            for (int j = 2; j < 11; j++)
            {
                Console.WriteLine(i + " in base " + j + " is " + i.ConverttoBase(j));
            }

         //   Console.WriteLine(i + "9  in base " + 9 + " is " + i.ConverttoBase(9));

        }

        static void Main()
        {
            try
            {
                doWork();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
        }
    }
}
