using System.Runtime.InteropServices;

public class Hose : Device
{
    private int _currentMoistness = 0;
    private string _flowType= "stream";
    private Dictionary<int, double> _waterSchedule = new Dictionary<int, double>();

    public override void Alert()
    {

    }

    public override void CheckLevel()
    {

    }
    public override void Display()
    {
        Console.WriteLine($"The soil is currently saturated with {_currentMoistness} percent water");
    }

    public void ScheduleWater()
    {
        Console.WriteLine("What type of watering do you want the hose to do? (drip, stream, flood, or rain) ");
        _flowType = Console.ReadLine();
        Console.WriteLine("How many hours of watering do you want each week? ");
        int numHours = int.Parse(Console.ReadLine());
        for(int i = 0; i < numHours; i++)
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

            else
            {
                _waterSchedule[i] = 1.5;
            }
            
        }
    }

    public void Water(int hour)
    {
        Console.WriteLine($"Plant given {_waterSchedule[hour]} units of water");
    }

    public Hose(float low, float high, string flowType) : base(low, high)
    {
        _flowType = flowType;
    }
}