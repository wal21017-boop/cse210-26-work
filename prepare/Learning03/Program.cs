using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction = new Fraction();
        fraction.GetTop();
        fraction.GetBottom();
        string frac = fraction.GetFractionString();
        double deci = fraction.GetDecimalValue();
        Console.WriteLine(frac);
        Console.WriteLine(deci);

        Fraction f2 = new Fraction(8);
        frac = f2.GetFractionString();
        deci = f2.GetDecimalValue();
        Console.WriteLine(frac);
        Console.WriteLine(deci);
        Fraction f3 = new Fraction(2,5);
        frac = f3.GetFractionString();
        deci = f3.GetDecimalValue();
        Console.WriteLine(frac);
        Console.WriteLine(deci);
        int times = 1;
        do
        {
            Random rand = new Random();
            fraction.SetTop(rand.Next(1,20));
            fraction.SetBottom(rand.Next(1,20));
            frac = fraction.GetFractionString();
            deci = fraction.GetDecimalValue();
            Console.WriteLine($"Fraction {times}: string: {frac}, Number: {deci}");
            times +=1;

        } while (times < 21);
    }
}