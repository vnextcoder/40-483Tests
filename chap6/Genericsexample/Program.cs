using System;

namespace Genericsexample {
    class Program {
        static void Main (string[] args) {
            //Console.WriteLine ("Hello World!");
            //CheckQuadilateral ();

            //CheckSquare ();
            RoundTest();
        }
        private static void RoundTest () {
            Round<decimal> rnd = new Round<decimal> ();

            rnd.Name = "General Round Shape";
            rnd.Display ();

            Console.WriteLine ();
            
        }
        private static void CheckSquare () {
            // Rectangle, in meters
            Square<Byte> plate = new Square<Byte> ();
            plate.Name = "Plate";
            plate.Base = 15;
            plate.Height = 28;
            plate.ShowCharacteristics ();

            Console.WriteLine ();

        }

        static void CheckQuadilateral () {
            // Trapezoid with equal sides
            Quadrilateral<double> Kite =
                new Quadrilateral<double> ("Beach Kite", 18.64, 18.64);
            Kite.ShowCharacteristics ();
            Console.WriteLine ();

            // Rectangle, in meters
            Quadrilateral<Byte> BasketballStadium = new Quadrilateral<Byte> ();
            BasketballStadium.Name = "Basketball Stadium";
            BasketballStadium.Base = 15;
            BasketballStadium.Height = 28;
            BasketballStadium.ShowCharacteristics ();
            Console.WriteLine ();
        }
    }
}