using System;

namespace HouseBoatpractice {

    interface IHouse {
        void opendoor ();

    }
    interface IBoat {
        void opendoor ();
         void jumpin ();

    }
    class HouseBoat : IHouse, IBoat, IDisposable {

        

        public void opendoor () {
            Console.WriteLine ("The Door of house is open");
            //IBoat.jumpin();
        }


        void IBoat.jumpin () {
            Console.WriteLine ("Welcome to the boat");
            //opendoor();
        }

        public void Dispose()
        {
            Console.WriteLine("Calling Dispose");

        }

    }
}