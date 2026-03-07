public class Breathing : Activity
{
    private string _in = "";
    private string _out = "";

    public Breathing(string bIn, string bOut, string description, string name, string endMessage) : base(description, name, endMessage)
    {
        _in = bIn;
        _out = bOut;
    }
    private void Countdown(int num)
    {
        for(int i = num; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b");
        }
    }

    private void BreathIn()
    {
        List<string> bits = new List<string>();
        bits.Add("|");
        bits.Add("||");
        bits.Add("|-|");
        bits.Add("|--|");
        bits.Add("|---|");
        foreach (string bit in bits)
        {
            Console.Write(bit);
            Thread.Sleep(1000);
            for (int i = bit.Length; i > 0; i --)
            {
                Console.Write("\b \b");
            }
            
        }
    }
    private void BreathOut()
    {
        List<string> bits = new List<string>();
        bits.Add("|---|");
        bits.Add("|--|");
        bits.Add("|-|");
        bits.Add("||");
        bits.Add("|");
        bits.Add("");
        foreach (string bit in bits)
        {
            Console.Write(bit);
            Thread.Sleep(1000);
            for (int i = bit.Length; i > 0; i --)
            {
                Console.Write("\b \b");
            }
        }
    }
    public void RunBreathing()
    {
        StartActivity();
        int time = 0;
        do{
        Console.Write(_in + " ");
        BreathIn();
        Console.WriteLine();
        time += 5;
        if (_duration < time)
            {
                break;
            }
        Console.Write(_out + " ");
        BreathOut();
        Console.WriteLine();
        time += 5;
        } while (_duration > time);
        DisplayEnd();


    }


}