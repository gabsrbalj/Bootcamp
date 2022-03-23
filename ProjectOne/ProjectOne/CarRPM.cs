using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne
{
    public class CarRPM : ICarRPMSolution
    {
        public void RPMCalculation()
        {
            Console.WriteLine("Enter Car Speed: ");
            int CarSpeed = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Tier Diameter:v");
            int TierDiameter = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Car RPM speed results: " + TierDiameter*60*Math.PI*CarSpeed/63360);
        }
    }
}
