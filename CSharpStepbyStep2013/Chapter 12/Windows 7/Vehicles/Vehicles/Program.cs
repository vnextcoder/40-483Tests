using System;

namespace Vehicles
{
    class Program
    {
        static void doWork()
        {
            Console.WriteLine("Journey by  Plane");

            AirPlane plane = new AirPlane();
            plane.StartEngine("ssssss..........");
            plane.TakeOff();
            plane.Drive();
            plane.Land();

            plane.StopEngine("brrr");
            //plane = null;

            Console.WriteLine("Journey by  Car");

            Car car = new Car();
            car.StartEngine("vrooom");
            car.Accelerate();
            car.Drive();
            car.Brake();
            car.StopEngine("bleeep");
            //car = null;


            Vehicle v = car;
            v.Drive();

            v = plane;
            v.Drive();



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
