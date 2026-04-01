public class Humidifier : Device
{
    private static Random random = new Random();
    private float _currentHumidity = random.NextSingle() * 100;
    private float _storedWater = 0;

    public override void Alert()
    {

    }

    public override void CheckLevel()
    {

    }

    public override void Display()
    {

    }

    public void DeHumidify()
    {
        if (_storedWater < 1)
        {    
            _currentHumidity -=1;
            _storedWater +=1;
        }
    }

    public void Humidify()
    {
        if (_storedWater > 0)
        {    
            _currentHumidity +=1;
            _storedWater -=1;
        }
    }

    public Humidifier(float low, float high) : base(low, high)
    {
        
    }
}