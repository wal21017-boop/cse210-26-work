using System;

class Program
{
    static void Main(string[] args)
    {   



        Scripture proverbs = new Scripture("Psalms 77:10-15", 
        @"And I said, This is my infirmity: but I will remember the years of the right hand of the most High. 
        I will remember the works of the Lord: surely I will remember thy wonders of old. 
        I will meditate also of all thy work, and talk of thy doings. Thy way, O God, is in the sanctuary: 
        who is so great a God as our God?
        Thou art the God that doest wonders: thou hast declared thy strength among the people.
        Thou hast with thine arm redeemed thy people, the sons of Jacob and Joseph. Selah.");

        Console.WriteLine("Welcome to the Scripture Memorizer! ");
        Console.Write("Would you like to use our preset scripture? (y/n) ");
        string yn = Console.ReadLine();
        if (yn == "y")
        {
            proverbs.Memorization();
        }
        if (yn == "n")
        {
            Scripture custom = new Scripture();
            custom.GetScripture();
            custom.Memorization();
        }
        


    }
}