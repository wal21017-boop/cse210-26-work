public class Humidifier : Device
{
    private float _currentHumidity;
    private float _storedWater;

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
        _currentHumidity -= 1;
    }

    public void Humidify()
    {
        _currentHumidity +=1;
    }

    public Humidifier(float low, float high) : base(low, high)
    {
        
    }
}