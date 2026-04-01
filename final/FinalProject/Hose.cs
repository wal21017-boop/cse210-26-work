public class Hose : Device
{
    private int _currentMoistness = 0;
    private string _flowType= "stream";
    private Dictionary<int, float> _waterSchedule = new Dictionary<int, float>();

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
        
    }

    public void Water()
    {
        
    }

    public Hose(float low, float high, string flowType) : base(low, high)
    {
        _flowType = flowType;
    }
}