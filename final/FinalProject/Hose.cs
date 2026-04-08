using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;

public class Hose : Device
{
    private double _currentMoistness = 0;
    private string _flowType= "stream";
    private Dictionary<int, double> _waterSchedule = new Dictionary<int, double>();

    public override void Alert()
    {
        Console.WriteLine("ERROR: soil moisture not within tolerance levels");
    }

    public override void CheckLevel()
    {
        if (_currentMoistness < _lowThreshold)
        {
            Alert();
        }
        else
        {
            Console.WriteLine($"Hose is ok");
        }
    }
    public override void Display()
    {
        Console.WriteLine($"Current soil moisture: {_currentMoistness}");
        Console.WriteLine($"Flow type: {_flowType}");
    }

    public void ScheduleWater()
    {
        Console.WriteLine("How many hours of watering do you want each day? ");
        int numHours = int.Parse(Console.ReadLine());
        if (numHours > _highThreshold || numHours < _lowThreshold)
        {
            Console.WriteLine($"Please enter a number less than {_highThreshold} and greater than {_lowThreshold}");
            numHours = int.Parse(Console.ReadLine());
        }

        for(int i = 0; i <= 24 ; i++)
        {
            if (i < numHours)
            {
                if (_flowType == "drip")
                {
                    _waterSchedule[i] = 0.1;
                }

                else if (_flowType == "stream")
                {
                    _waterSchedule[i] = 2.0;
                }

                else if (_flowType == "flood")
                {
                    _waterSchedule[i] = 3.5;
                }

                else if (_flowType == "rain")
                {
                    _waterSchedule[i] = 1.5;
                }
            }
            else
            {
                _waterSchedule[i] = 0;
            }
            
        }
    }

    public void Water(int hour)
    {
        if (_waterSchedule[hour] > 0)
        {
            
            Console.WriteLine($"Plant given {_waterSchedule[hour]} units of water at {hour}:00");
            _currentMoistness += _waterSchedule[hour];
        }
    }

    public Hose(float low, float high, string flowType) : base(low, high)
    {
        _flowType = flowType;
        ScheduleWater();
    }

    public override void NextDay()
    {
        for(int i = 0; i <=24; i++)
        {
            Water(i);
        }
        _currentMoistness -= 1;
    }

    public Hose(float low, float high, string flowType, int current) : base(low, high)
    {
        _flowType = flowType;
        _currentMoistness = current;
        ScheduleWater();
    }
    public override string Save()
    {
        return $"Device~water~{_lowThreshold}~{_highThreshold}~{_flowType}~{_currentMoistness}~";
    }

}