using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Car:Vehicle
    {
        public void Accelerate()
        {
            Console.WriteLine("Accelerating ");

        }
        public void Brake()
        {
            Console.WriteLine("Brake applied");

        }
        public override void Drive()
        {
            Console.WriteLine("Motoring" + this.GetType().Name);
            //base.Drive();
            

        }
        
    }
}
