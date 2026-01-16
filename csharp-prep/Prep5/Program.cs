using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        string name;
        int num;
        int year;
        int square;
        DisplayWelcome();
        PromptUserName(out name);
        PromptUserNumber(out num);
        PromptUserBirthYear(out year);
        SquareNumber(num, out square);
        DisplayResult(name,square,year);

    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program! ");
    }
    static void PromptUserName(out string name)
    {
        Console.Write("Please enter your name: ");
        name = Console.ReadLine();
    }
    static void PromptUserNumber(out int num)
    {
        Console.Write("Please enter your favorite number: ");
        string number = Console.ReadLine();
        num = int.Parse(number);
    }
    static void PromptUserBirthYear(out int year)
    {
        Console.Write("Please enter the year you were born: ");
        string yr = Console.ReadLine();
        year = int.Parse(yr);
    }
    static void SquareNumber(int num, out int square)
    {
        square = num*num;
    }
    static void DisplayResult(string name, int square, int year)
    {
        Console.WriteLine($"{name}, your number squared is: {square}");
        Console.WriteLine($"{name}, you will turn {2026-year} this year");
    }
}