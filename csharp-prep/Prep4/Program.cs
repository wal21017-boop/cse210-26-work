using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
class Program
{
    static void Main(string[] args)
    {
        List<int> numbers =  new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished");
        int number;
        do 
        {   
            Console.Write("Enter number: ");
            string num = Console.ReadLine();
            number = int.Parse(num);
            if (number != 0)
            {
                numbers.Add(number);
            }
        } while(number != 0);
        Console.WriteLine($"The sum is {numbers.Sum()}");
        Console.WriteLine($"The average is {numbers.Average()}");
        Console.WriteLine($"The largest number is {numbers.Max()}");
    }
}