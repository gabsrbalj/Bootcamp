using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne
{
     public class EquationSolution : Equation
    {
        public override void Displacement()
        {
            Console.WriteLine("Enter Stroke Number: ");
            int Stroke = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Number Of Cylinders: ");
            int NumberOfCylinders = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Displacement Number of your car is: " + Math.PI + Stroke + NumberOfCylinders);

        }
    }
}
