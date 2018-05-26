using System;

namespace HouseBoatpractice {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");

            HouseBoat b = new HouseBoat ();
            //b.jumpin();
            b.opendoor ();
            IHouse h = (IHouse) b;

            h.opendoor ();

            // h=null;
            // b=null;

            string a = "Hello";

            string b = "Hello";
            string c = "Hello";

            c = c.ToUpper (); //HELLO

            string d = "Hello";


            string d=d.SubString(0,2);
            string d=d.SubString(0,1);
            

        }
    }
}