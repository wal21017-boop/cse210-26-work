using System.Transactions;

public class Humidifier : Device
{
    private static Random _random = new Random();
    private float _currentHumidity = _random.NextSingle() * 100;
    private float _storedWater = 0;

    public override void Alert()
    {
        if (_storedWater >= 100)
        {
            
            Console.WriteLine($"Error! Humidifier is full please empty halfway (click enter)");
            for (int i = 0; i <= 50; i+=10)
            {
                Console.WriteLine($"Current Water level (out of 100): {_storedWater}");
                Console.ReadLine();
                _storedWater-=10;
            }
        }
        else
        {
            _storedWater = 0;
            Console.WriteLine($"Error! Humidifier is empty, please fill halfway (press enter to fill)");
            for (int i = 0; i >= 50; i+=10)
            {
                Console.WriteLine($"Current Water level (out of 100): {_storedWater}");
                Console.ReadLine();
                _storedWater+=10;
            }
        }
        Console.WriteLine($"Error! Humidifier is full");
    }

    public override void CheckLevel()
    {
        Humidify();
        DeHumidify();

    }

    public override void Display()
    {
        Console.WriteLine($"Current Humidity: {_currentHumidity}");
        Console.WriteLine($"Current Water level (out of 100): {_storedWater}");
    }

    public void DeHumidify()
    {
        if (_storedWater < 100 && _currentHumidity > _highThreshold)
        {    
            _currentHumidity -=1;
            _storedWater +=1;
        }
    }

    public void Humidify()
    {
        if (_storedWater > 0 && _currentHumidity < _lowThreshold)
        {    
            _currentHumidity +=1;
            _storedWater -=1;
        }
        else
        {
            Console.WriteLine($"Would you like to refill the humidifier? (y/n)");
            string yn = Console.ReadLine();
            if (yn == "y")
            {
                _storedWater = 50;
            }
        }
    }

    public Humidifier(float low, float high) : base(low, high)
    {
        
    }

    public Humidifier(float low, float high, float current, float stored) : base(low, high)
    {
        _currentHumidity = current;
        _storedWater = stored;
    }
    public override string Save()
    {
        return $"Device~humid~{_lowThreshold}~{_highThreshold}~{_currentHumidity}~{_storedWater}~";
    }


    public override void NextDay()
    {
        CheckLevel();
        _currentHumidity-= _random.Next(0,1);

        if(_storedWater <= 0 || _storedWater >= 100)
        {
            Alert();
        }

    }
}