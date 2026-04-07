public class Thermostat : Device
{
    private float _currentTemp;

    public override void CheckLevel()
    {
        do
        {
            
        if (_currentTemp > _highThreshold)
        {
            Cool();
        }

        else if (_currentTemp < _lowThreshold)
        {
            Heat();
        }
        } while (_currentTemp > _highThreshold || _currentTemp < _lowThreshold);
    }

    public override void Alert()
    {
        
    }

    public override void Display()
    {
        Console.WriteLine($"Current temp: {_currentTemp}");
    }
    public void ScheduleTemp()
    {
        Console.WriteLine("What is the lowest temp the Greenhouse can be?");
        _lowThreshold = float.Parse(Console.ReadLine());
        Console.WriteLine("What is the highest temp the Greenhouse can be?");
        _highThreshold = float.Parse(Console.ReadLine());
    }

    public void Heat()
    {
        _currentTemp += 1;
    }

    public void Cool()
    {
        _currentTemp -= 1;
    }

    public Thermostat(float low, float high) : base(low, high)
    {
        
    }

    public Thermostat(float low, float high, float current) : base(low, high)
    {
        _currentTemp = current;
    }
    public override string Save()
    {
        return $"Device~temp~{_lowThreshold}~{_highThreshold}~{_currentTemp}~";
    }

    public override void NextDay()
    {
        Random random = new Random();
        _currentTemp -= random.Next(1,10);
        CheckLevel();

    }
}