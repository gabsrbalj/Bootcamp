using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne
{
    public class Vechicle : Car
    {
        public int Kilometers { get; set; }

        public void  DisplayOfCarID()
        { 
            Console.WriteLine(CarID);
        }
        public virtual void TraveledKilometers()
        {
            if(Used == true)
            {
                Console.WriteLine("Kilometers Traveled:");
            }
        }
    }
}
