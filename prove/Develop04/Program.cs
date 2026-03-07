using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        string bIn = "Breathe In";
        string bOut = "Breathe Out";
        string description = "This activity will help promote relaxation by encouraging you to breathe in and out in time with our prompts";
        string name = "Breathing";
        string endMessage = "Great Job!";
        
        Breathing breath = new Breathing(bIn, bOut, description, name, endMessage);

        List<string> reflectPrompts = new List<string>
        {
            "Think of a time when you acted with courage.",
            "Think of a time when you admitted to a mistake even when it was hard.",
            "Think of a time when you persevered through a difficult trial.",
            "Think of a time when you chose something right over something easy.",
            "Think of a time when you mentored or taught someone a new skill.",
            "Think of a time when you stayed calm during a high-pressure situation.",
            "Think of a time when you sacrificed your own comfort to help someone."
        };
        List<string> reflectQuestions = new List<string>
        {
            "What was the most challenging part of that experience?",
            "If you could go back, would you change anything about what you did?",
            "Who else was impacted by your actions, and how do you think they felt?",
            "What personal abilities did you rely on most during this experience?",
            "Did this change your perspective on anything?",
            "How would you describe this experience to your younger self?",
            "Did you have to give up anything during this experience?",
            "How did this bridge the gap between who you were and who you are now?",
            "What advice would you give to someone else facing a similar situation?",
            "Was there a moment where you felt like giving up? What kept you going?",
            "How has your confidence in your own abilities changed as a result of this event?",
            "What did this experience tell you about yourself?",
            "In what way did this experience surprise you the most?"
        };

        string rdescription = "This activity will help you reflect on times in your life where you made an impact or overcame adversity to achieve something. This will help you recognize your ability to make an impact in the world.";
        string rname = "Reflection";

        Reflection reflect = new Reflection(reflectPrompts, reflectQuestions, rdescription, rname, endMessage);

        List<string> listPrompts = new List<string>
        {
            "When have you felt peace this week?",
            "What small details in nature have you noticed and appreciated recently?",
            "Who are people that have shaped the person you are becoming?",
            "What are trials you’ve faced that eventually turned into a blessing?",
            "How have you shown kindness to yourself recently?",
            "What experiences have given you strength lately?",
            "When have you felt answers to prayers this week?",
            "Who are some people who you haven't thanked lately that deserve your gratitude?"
        };
        List<string> things = new List<string>();
        string ldescription = "This activity helps remind you of times of peace or happiness that have happened in your life by helping you list things of a specific nature.";
        string lname = "Listing";
        Listing llist = new Listing(listPrompts, things, ldescription, lname, endMessage);
        
        Console.WriteLine("Welcome to Peaceful Ponderings. \nWe hope our mindfulness activites will bring you peace.");
        int choice = 0;
        do
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1: Breathing Activity");
            Console.WriteLine("2: Reflection Activity");
            Console.WriteLine("3: Listing Activity");
            Console.WriteLine("4: Quit");
            Console.Write("Choose an option from the menu: ");
            choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                breath.RunBreathing();
            }
            else if (choice == 2)
            {
                reflect.RunReflection();
            }
            else if (choice == 3)
            {
                llist.RunListing();
            }
            else if (choice == 4)
            {
                Console.WriteLine("Thanks for practicing mindfulness with us! Have a wonderful day!");
            }
            else
            {
                Console.WriteLine("Please choose a valid option");
            }
        }while(choice != 4);
        
    }
}