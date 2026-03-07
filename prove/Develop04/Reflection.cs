using System.Diagnostics.CodeAnalysis;
using System.Transactions;

public class Reflection : Activity
{
    List<string> _prompts = new List<string>();
    List<string> _questions = new List<string>();
    public Reflection(List<string> prompts, List<string> questions, string description, string name, string endMessage) : base(description, name, endMessage)
    {
        _prompts = prompts;
        _questions = questions;
    }

    public string ChoosePrompt()
    {
        Random choice = new Random();
        int num = choice.Next(0,_prompts.Count);
        return _prompts[num];
    }

    public string ChooseQuestion()
    {
        Random choice = new Random();
        int num = choice.Next(0,_questions.Count);
        return _questions[num];
    }


    public void RunReflection()
    {
        string prompt = ChoosePrompt();
        StartActivity();
        Console.WriteLine($"____{prompt}____");
        Console.WriteLine("When you have something in mind, press enter to continue");
        Console.ReadLine();
        DateTime time = DateTime.Now;
        DateTime end = time.AddSeconds(_duration);
        do
        {
            if (time.AddSeconds(10) < end)
            {
                string question = ChooseQuestion();
                Console.WriteLine(question);
                GeneralAnimation(10000);
            }
            else if (time.AddSeconds(5) < end)
            {
                string question = ChooseQuestion();
                Console.WriteLine(question);
                GeneralAnimation(5000);
            }
            else
            {
                GeneralAnimation(1000);
            }
            time = DateTime.Now;
        }while (time < end);
        DisplayEnd();
        
    }
}