using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        
        Job job1 = new Job();
        job1._jobTitle = "Campus Security Dispatcher";
        job1._company = "BYU-Idaho";
        job1._startYear = 2024;
        job1._endYear = 2026;

        Job job2 = new Job();
        job2._jobTitle = "Cashier and Coach";
        job2._company = "Gravity Factory";
        job2._startYear = 2021;
        job2._endYear = 2022;
        

        Resume new_resume = new Resume();
        new_resume._name = "Brian Walsh";
        new_resume._jobs.Add(job1);
        new_resume._jobs.Add(job2);
        new_resume.Display();
    }
}