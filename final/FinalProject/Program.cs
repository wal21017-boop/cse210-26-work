using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Greenhouse Simulator!");
        Console.WriteLine("Would you like to continue a previous simulation? (y/n)");
        string yn = Console.ReadLine();
        if (yn == "y")
        {
            Console.WriteLine("What is the name of the greenhouse you would like to load?");
            Greenhouse greenhouse = new Greenhouse(Console.ReadLine());
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

            Greenhouse greenhouse = new Greenhouse(name, length, width, height);
        }

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
            Console.WriteLine("5: Quit");
            option = int.Parse(Console.ReadLine());
            
        } while (option != 5);
    }
}