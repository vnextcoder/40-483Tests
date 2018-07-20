using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class AirPlane:Vehicle
    {

        public void TakeOff()
        {
            Console.WriteLine("Taking off");

        }

        public void Land()
        {
            Console.WriteLine("Landed plane");

        }
    }
}
