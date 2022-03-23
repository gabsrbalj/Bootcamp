using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne
{
    public class Auto : Vechicle
    {
        public override void TraveledKilometers()
        {
            if(Used == false)
            {
                Console.WriteLine("This car did not pass any kilometer.");
            }
        }
    }
}
