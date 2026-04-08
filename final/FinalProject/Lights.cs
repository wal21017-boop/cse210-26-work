using System.Formats.Asn1;

public class Lights : Device
{
    private Dictionary<int, bool> _lightSchedule = new Dictionary<int, bool>();

    public override void Alert()
    {
        Console.WriteLine("Lights Error");
    }

    public override void CheckLevel()
    {
        
        Display();
    
    }

    public override void Display()
    {
        for(int i=0; i <= 24; i++)
            {
                if (i > 0)
                {
                    if (_lightSchedule[i] != _lightSchedule[i - 1])
                    {
                        Console.WriteLine($"{i}:00, lights off");
                    }
                }
                else if (_lightSchedule[i])
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
        for(int i = 0; i <= 24; i++)
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
        ScheduleLights();
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