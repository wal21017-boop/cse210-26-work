using System;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Greenhouse Simulator!");
        Console.WriteLine("Would you like to continue a previous simulation? (y/n)");
        string yn = Console.ReadLine();
        Greenhouse greenhouse;
        if (yn == "y")
        {
            Console.WriteLine("What is the name of the greenhouse you would like to load?");
            greenhouse = new Greenhouse(Console.ReadLine());
            greenhouse.LoadGreenhouse();
        }
        else
        {
            Console.WriteLine("What would you like to name this greenhouse? ");
            string name = Console.ReadLine();
            Console.WriteLine("What width (in meters) is your greenhouse? ");
            float width = float.Parse(Console.ReadLine());
            Console.WriteLine("What width (in meters) is your greenhouse? ");
            float length = float.Parse(Console.ReadLine());
            Console.WriteLine("What height (in meters) is your greenhouse? ");
            float height = float.Parse(Console.ReadLine());
            float overallArea = 0;
            Console.WriteLine("How many plots does your greenhouse have? ");
            int plots = int.Parse(Console.ReadLine());
            greenhouse = new Greenhouse(name, length, width, height);
            for (int i = 1; i <= plots; i++)
            {
                Console.WriteLine($"Describe the location of plot {i} for later reference");
                string location = Console.ReadLine();
                Console.WriteLine($"How much shade does plot {i} get on a scale from 1 to 10");
                float shade = float.Parse(Console.ReadLine());
                Console.WriteLine($"What is the length of plot {i}");
                float plotLength = float.Parse(Console.ReadLine());
                Console.WriteLine($"What is the width of plot {i}");
                float plotWidth = float.Parse(Console.ReadLine());
                
                overallArea += (plotLength * plotWidth);

                if (overallArea > length * width)
                {
                    Console.WriteLine("ERROR: Area of plots is greater than the area of the greenhouse.");
                    break;
                }
                else
                {
                    greenhouse.AddContainer("plot", location, shade, length, width, i);
                }
                

                
            }
        }
        int potNums = 0;
        int option = -999;
        do
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the Greenhouse menu");
            Console.WriteLine("Would you like to: ");
            Console.WriteLine();
            Console.WriteLine("1: Plant a new plant");
            Console.WriteLine("2: See how your garden is doing");
            Console.WriteLine("3: Check device levels");
            Console.WriteLine("4: Move to the next day");
            Console.WriteLine("5: Save Progress");
            Console.WriteLine("6: Quit");
            option = int.Parse(Console.ReadLine());

            if (option == 1)
            {
                Console.WriteLine("Are you planting this plant in a pot? (y/n) ");
                if (Console.ReadLine() == "y")
                {
                    potNums +=1;
                    Console.WriteLine("Describe the location of the pot so you can find it later");
                    string location = Console.ReadLine();
                    Console.WriteLine($"How much shade does pot {potNums} get on a scale from 1 to 10");
                    float shade = float.Parse(Console.ReadLine());
                    Console.WriteLine($"What is the depth of pot {potNums}");
                    float depth = float.Parse(Console.ReadLine());
                    Console.WriteLine($"What is the radius of pot {potNums}");
                    float radius = float.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine("What is the common name of the plant you want to plant?");
                    string name = Console.ReadLine();
                    greenhouse.AddContainer("pot", location, shade, depth, radius, potNums +1);
                    greenhouse.AddPlant(greenhouse.NumContainers() - 1, name);
                }
                else
                {
                    Console.WriteLine("What plot number are you planting this plant in?");
                    int num = int.Parse(Console.ReadLine());
                    Console.WriteLine("What is the common name of the plant you want to plant?");
                    string name = Console.ReadLine();
                    greenhouse.AddPlant(num, name);
                }
            }
            
        } while (option != 6);
    }
}