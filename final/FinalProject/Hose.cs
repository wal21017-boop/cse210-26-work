public class Hose : Device
{
    private float _currentMoistness;
    private string _flowType;
    private Dictionary<int, float> _waterSchedule = new Dictionary<int, float>();

    public override void Alert()
    {

    }

    public override void CheckLevel()
    {

    }
    public override void Display()
    {

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