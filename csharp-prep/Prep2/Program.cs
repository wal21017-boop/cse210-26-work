using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the AutoGrader!");
        Console.Write("What grade percentage did you get in your course? ");
        string grade = Console.ReadLine();
        Console.Write(grade);
        int gradeNum = int.Parse(grade);
        string gradeLetter;
        bool pass;
        if (gradeNum >= 90)
        {
            gradeLetter = "A";
            pass = true;
        }
        else if (gradeNum >= 80)
        {
            gradeLetter = "B";
            pass = true;
        }
        else if (gradeNum >= 70)
        {
            gradeLetter = "C";
            pass = true;
        }
        else if (gradeNum >= 60)
        {
            gradeLetter = "D";
            pass = false;
        }
        else
        {
            gradeLetter = "F";
            pass = false;
        }
        int lastDigit = gradeNum % 10;
        string plusMinus;
        if (lastDigit < 3)
        {
            plusMinus = "-";
        }
        else if (lastDigit  >= 7)
        {
            plusMinus = "+";
        }
        else
        {
            plusMinus = "N/A";
        }
        if (plusMinus != "N/A" && (gradeLetter != "A" && gradeLetter != "F"))
        {
            gradeLetter = gradeLetter + plusMinus;
        }
        else if (gradeLetter == "A" && plusMinus == "-")
        {
            gradeLetter = gradeLetter + plusMinus;
        }
        Console.WriteLine($"You acheived a {gradeLetter} letter grade");
        if (pass == true)
        {
            Console.WriteLine("");
            Console.WriteLine("Congratulations! You passed the class");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Sorry! You failed the course.");
        }
        
    }   
}