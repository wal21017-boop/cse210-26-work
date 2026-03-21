using System;
using System.Globalization;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Welcome to the GOALP ");
        Thread.Sleep(500);
        Console.WriteLine("Goal");
        Thread.Sleep(500);
        Console.WriteLine("Operating");
        Thread.Sleep(500);
        Console.WriteLine("And");
        Thread.Sleep(500);
        Console.WriteLine("Logging");
        Thread.Sleep(500);
        Console.WriteLine("Program");
        Thread.Sleep(500);
        Console.WriteLine("Would you like to a load a previous profile or create a new one?");
        Console.Write("Enter l for load or c for create: ");
        PlayerProfile player = new PlayerProfile();
        string ls = Console.ReadLine();
        if (ls == "l")
        {
            player = new PlayerProfile();
            Console.Write("What was the name or alias of the previous profile? ");
            string name = Console.ReadLine();
            player.SetPlayerName(name);
            player.LoadProfile();
        }

        else
        {
            player = new PlayerProfile();
            player.CreateProfile();
        }
        
        int option = -999;
        int times = 0;
        do
        {
            times +=1;
            Console.Clear();
            player.DisplayPoints();
            Console.WriteLine("Welcome to the GOALP menu");
            Console.WriteLine("Would you like to: ");
            Console.WriteLine("1: Create a new goal");
            Console.WriteLine("2: Display profile and goals");
            Console.WriteLine("3: Record goal progress");
            Console.WriteLine("4: Quit");
            try
            {
                
            
            option = int.Parse(Console.ReadLine());
            }
            catch
            {
                option = 0;
                Console.WriteLine("Please enter a number!");
                Thread.Sleep(500);
            }
            if (option == 1)
            {
                Console.Clear();
                Console.WriteLine("Is your goal complete after one time? (y/n)");
                string yn = Console.ReadLine();
                if (yn == "y")
                {
                    Goal goal = new SimpleGoal();
                    goal.CreateGoal();
                    player.AddGoal(goal);
                    Console.WriteLine("Goal created");
                }
                else if (yn == "n")
                {
                    Console.WriteLine("Does your goal have a specific number of times until it is completed? (y/n) : ");
                    yn = Console.ReadLine();
                    if (yn == "n")
                    {
                        Sisyphus newGoal = new Sisyphus();
                        newGoal.CreateGoal();
                        player.AddGoal(newGoal);
                        Console.WriteLine("Goal created");
                    }
                    else if (yn == "y")
                    {
                        ListGoal lister = new ListGoal();
                        lister.CreateGoal();
                        player.AddGoal(lister);
                        Console.WriteLine("Goal created");
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: Something went wrong, you may have mistyped");
                }
                Thread.Sleep(500);
            }
            else if (option == 2)
            {
                Console.Clear();
                player.DisplayProfile();
                Console.ReadLine();
            }
            else if (option == 3)
            {
                Console.Clear();
                player.DisplayShortProfile();
                Console.Write("Please enter the number of the goal you'd like to record progress for : ");
                int choice = int.Parse(Console.ReadLine());
                player.RecordEvent(choice);
            }
            else if (option == 4)
            {
                break;
            }
            else if (option == 5)
            {
                Console.Clear();
                Console.WriteLine("Welcome to...");
                Thread.Sleep(500);
                Console.WriteLine("THE UNDERWORLD");
                Thread.Sleep(1000);
                Console.WriteLine("Sponsored by yours truly...");
                Thread.Sleep(500);
                Console.WriteLine("HADESSSSSS");
                Thread.Sleep(250);
                Console.WriteLine("\\     O   O     ");
                Thread.Sleep(250);
                Console.WriteLine(" \\      o       ");
                Thread.Sleep(250);
                Console.WriteLine("  \\  \\____/  ");
                Thread.Sleep(250);
                Console.WriteLine("   \\__|||||__");
                Thread.Sleep(250);
                Console.WriteLine("      |||||  \\");
                Thread.Sleep(250);
                Console.WriteLine("              \\");
                Thread.Sleep(250);
                Console.WriteLine("----------------");
                Thread.Sleep(1000);
                Console.WriteLine("Want to escape? You just have to guess the number I'm thinking of");
                Thread.Sleep(500);
                Console.WriteLine("I might even give you a point or two if you manage to escape");
                Random random = new Random();
                int hiddenNumber = random.Next(1,50);
                int guess = -999;
                int numTimes = 0;
                int points = 0;
                do
                {
                    
                    numTimes +=1;
                    Console.WriteLine("What number would you like to guess? ");
                    guess = int.Parse(Console.ReadLine());

                    if (numTimes >= 5)
                    {
                        
                        hiddenNumber = random.Next(1,20);
                        
                    }
                    else if (numTimes >= 10)
                    {
                        hiddenNumber = random.Next(1,10);
                        points = 10/numTimes;
                        player.AddPoints(points);
                        
                    }
                    else if (numTimes > 15)
                    {
                        Console.WriteLine("You are really bad at this game.");
                        Console.WriteLine("I'm going to let you leave, but I'm taking 10 of your points for wasting my time");
                        points = -10;
                        player.AddPoints(points);
                        break;
                    }

                    if (guess == hiddenNumber)
                    {
                        Console.WriteLine("Lucky guess. I guess I'll give you something for the entertainment");
                        points = 50/numTimes;
                        player.AddPoints(points);
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("HAHAHAHAHAHAHAHAHAHAHAHA");
                        Thread.Sleep(250);
                        Console.WriteLine("WRONG!!!!!!!!!!!!!!!!!!!");
                        Thread.Sleep(250);
                        Console.WriteLine("HAHAHAHAHAHAHAHAHAHAHAHA");
                    }

                    
                    
                } while (guess != hiddenNumber);
            }
            
            
            
            
        } while(option < 6);

        Console.WriteLine("Goodbye!");
        player.SaveProfile();
    }
}