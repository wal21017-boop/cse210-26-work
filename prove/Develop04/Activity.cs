
public class Activity
{
    protected int _duration = 0;
    protected string _description = "";
    protected string _name = "";
    protected string _endingMessage = "";

    protected void GeneralAnimation(int time)
    {
        List<string> bits = new List<string>();
        bits.Add("=");
        bits.Add("//");
        bits.Add("||");
        bits.Add("\\\\");
        
        int animate = 0;
        do
        {
            foreach (string bit in bits)
            {
                Console.Write(bit);
                Thread.Sleep(500);
                animate +=500;
                if(bit.Length == 1)
                {
                    Console.Write("\b \b");
                }
                else
                {
                    Console.Write("\b\b  \b\b");
                }
                if (animate > time)
                {
                    break;
                }
                
            }
            if (animate > time)
                {
                    break;
                }
            
        }while (animate < time);

    }

    public void GetDuration()
    {
        Console.Write($"How long (in seconds) would you like the {_name} activity to last? ");
        string num = Console.ReadLine();
        int time = int.Parse(num);
        _duration = time;
    }
    public void StartActivity()
    {
        Console.WriteLine($"Welcome to the {_name} Activity");
        Console.WriteLine("---------     --------");
        Console.WriteLine($"{_description}");
        Console.WriteLine("---------     --------");
        GetDuration();
        Console.Write("Prepare to Begin ");
        GeneralAnimation(5000);
        Console.Clear();
    }
    public void DisplayEnd()
    {
        Console.WriteLine($"You did the {_name} activity for {_duration} seconds!");
        GeneralAnimation(1000);
        Console.Write(_endingMessage+ " ");
        GeneralAnimation(10000);
        Console.Clear();
    }
    public Activity(string description, string name, string endMessage)
    {
        _description = description;
        _name = name;
        _endingMessage = endMessage;
        _duration = 0;
    }
}