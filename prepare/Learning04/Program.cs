using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Assignment no = new Assignment("Mulberry Jackson", "Math");
        string sum = no.GetSummary();
        Console.WriteLine(sum);

        MathAssignment math = new MathAssignment("HeeHee Jackson", "Algebra", "1.1", "3-10");
        string bit1 = math.GetSummary();
        string bit2 = math.GetHomeworkList();
        Console.WriteLine(bit1);
        Console.WriteLine(bit2);

        WritingAssignment write = new WritingAssignment("Little Larry", "Journaling 101", "My First Journal");
        string info1 = write.GetSummary();
        string info2 = write.GetWritingInformation();
        Console.WriteLine(info1);
        Console.WriteLine(info2);
    }
}