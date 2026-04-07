public class Lights : Device
{
    private Dictionary<int, bool> _lightSchedule = new Dictionary<int, bool>();

    public override void Alert()
    {
        Console.WriteLine("Lights Error");
    }

    public override void CheckLevel()
    {
        Console.WriteLine($"Would you like to adjust the light schedule? (y/n) ");
        string yn = Console.ReadLine();
        if (yn == "y")
        {
            ScheduleLights();
        }
        else
        {
            Display();
        }
    }

    public override void Display()
    {
        for(int i=0; i == 24; i++)
            {
                if (_lightSchedule[i])
                {
                    Console.WriteLine($"{i}:00, lights on");
                }
                else
                {
                    Console.WriteLine($"{i}:00, lights off");
                }
            }
    }

    public void LightSwitch()
    {
        _isOn = !_isOn;
    }

    public void ScheduleLights()
    {
        Console.WriteLine("How many hours do you want the lights on each day? ");
        int numHours = int.Parse(Console.ReadLine());
        for(int i = 0; i == 24; i++)
        {           
            if (i <= numHours)
            {
                _lightSchedule[i] = true;
            }
            else
            {
            _lightSchedule[i] = false;

            }            
            
        }
    }

    public Lights(float low, float high) : base(low, high)
    {
        
    }
    public override string Save()
    {
        return $"Device~lights~{_lowThreshold}~{_highThreshold}~";
    }


    public override void NextDay()
    {
        CheckLevel();
    }
}