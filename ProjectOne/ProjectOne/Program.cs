using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne
{
    class Program
    {
        static void Main(string[] args)
        {



            Auto vecobj = new Auto();

            


                Console.WriteLine("---Enter a number of desired action without dot-----\n");
                Console.WriteLine("1. Output of attributes of default car ");
                Console.WriteLine("2. Calculating a number of displacement or RPM ");
                Console.WriteLine("3. Entering new car information and output");
                Console.WriteLine("4. Entering additional car parts into list");
                Console.WriteLine("5. Exit Out");


                Console.WriteLine("Input Number:");
                int NumberOfChoice = Convert.ToInt32(Console.ReadLine());

                switch (NumberOfChoice)
                {
                    case 1:

                        vecobj.Type = "Ford";
                        vecobj.Used = true;
                        vecobj.Price = 160000;
                        vecobj.EngineType = "Diesel";
                        Console.WriteLine("----Default Car Attributes-----\n");
                        Console.WriteLine("Type Of Car: " + vecobj.Type + "\n" + "Used: " + vecobj.Used + "\n" + "Car price: " + vecobj.Price + "\n" + "Engine Type: " + vecobj.EngineType);
                        Console.WriteLine("Engine Power in kW: " + vecobj.EnginePower);
                        vecobj.TraveledKilometers();
                        vecobj.Kilometers = 170000;
                        Console.WriteLine("Passed kilometers: " + vecobj.Kilometers);

                        break;

                    case 2:

                        EquationSolution equationobj = new EquationSolution();
                        CarRPM rpmobj = new CarRPM();
                        Console.WriteLine("\n ----Enter number 1 for new calculation----\n");
                        int Choice = Convert.ToInt32(Console.ReadLine());

                        if (Choice == 1)
                        {
                            Console.WriteLine("\n");
                            equationobj.Displacement();
                            Console.WriteLine("\n");
                            rpmobj.RPMCalculation();
                            Console.WriteLine("\n");
                        }
                        else
                        {
                            Console.WriteLine("Calculations Complete");
                        }



                        break;

                    case 3:

                        Console.WriteLine("-----Enter New Car Information----");
                        Console.WriteLine("Enter car type: ");
                        vecobj.Type = Console.ReadLine();
                        Console.WriteLine("Enter car usage true or false: ");
                        vecobj.Used = Convert.ToBoolean(Console.ReadLine());
                        Console.WriteLine("Enter car price: ");
                        vecobj.Price = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter engine type: ");
                        vecobj.EngineType = Console.ReadLine();
                        Console.WriteLine("Enter engine power in kW: ");
                        vecobj.EnginePower = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Unique generated car ID: ");
                        vecobj.DisplayOfCarID();

                        Console.WriteLine("Output of entered data:");
                        Console.WriteLine("Car Type:" + vecobj.Type + "\nUsed:" + vecobj.Used + "\nPrice:" + vecobj.Price + "\nEngine Type:" + vecobj.EngineType + "\nEngine Power:" + vecobj.EnginePower);

                         break;

                    
                    case 4:

                        Console.WriteLine("----ENTER ADDITIONAL CAR PARTS----");
                        List<String> CarAcessories = new List<String>();
                        
                        Console.WriteLine("Enter a number of car parts you want to input:");
                        int CarPartsNumber = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter car parts:\n");
                        for (int IterationNumber=0; IterationNumber<CarPartsNumber; IterationNumber++)
                        {
                            String ListInput = Console.ReadLine();
                            CarAcessories.Add(ListInput);
                        }

                        Console.WriteLine("---Output of entered list data---\n");
                        foreach (var Acessories in CarAcessories)
                        {
                            Console.WriteLine(Acessories);
                        }

                        break;

                    case 5:

                        Console.WriteLine("Enter Y for exiting:");
                        string ExitingChoice = Console.ReadLine();

                        if (ExitingChoice == "Y")
                        {
                            Console.WriteLine("Thank you!");
                            break;
                        }

                        break;
                }


                

            

           

            Console.ReadLine();
        }
    }
}
