using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Vehicle
    {
        public void StartEngine(string noisetoMake)
        {

            Console.WriteLine("Starting Engine : {0}", noisetoMake);

        }
        public void StopEngine(string noisetoMake)
        {

            Console.WriteLine("Stopping Engine : {0}", noisetoMake);

        }


        public virtual void Drive()
        {

            Console.WriteLine("Default implementation of Drive method" + this.GetType().Name);
        }
    }
}
