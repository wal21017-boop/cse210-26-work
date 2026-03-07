using System.Security.Cryptography;

public class Listing : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _things = new List<string>();
    public Listing(List<string> prompts, List<string> things, string description, string name, string endMessage) : base(description, name, endMessage)
    {
        _prompts = prompts;
        _things = things;
    }
    private void ListThings()
    {
        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(_duration);
        DateTime current = DateTime.Now;
        do
        {
           Console.WriteLine();
           Console.Write("-> ");
           _things.Add(Console.ReadLine()); 
           current = DateTime.Now;
        } while(current < end);
    }

    public string ChoosePrompt()
    {
        Random choice = new Random();
        int num = choice.Next(0,_prompts.Count);
        return _prompts[num];
    }

    public void RunListing()
    {
        StartActivity();
        string prompt = ChoosePrompt();
        Console.WriteLine("List as many responses to the following prompt as you can");
        Console.WriteLine("\\\\\\\\----------////");
        Console.WriteLine(prompt);
        Console.WriteLine("////----------\\\\\\\\");
        Console.Write("Start in ");
        for (int i = 6; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(750);
            Console.Write("\b \b");
        }
        ListThings();
        Console.WriteLine($"You listed {_things.Count} responses!");
        DisplayEnd();

    }
}