public class Thermostat : Device
{
    private float _currentTemp;
    private Dictionary<int, float> _tempSchedule = new Dictionary<int,float>();

    public override void CheckLevel()
    {
        
    }

    public override void Alert()
    {
        
    }

    public override void Display()
    {
        
    }
    public void ScheduleTemp()
    {
        // Get needed temp from here
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
}