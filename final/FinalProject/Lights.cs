public class Lights : Device
{
    private int _intensity;
    private Dictionary<int, float> _lightSchedule = new Dictionary<int, float>();

    public override void Alert()
    {

    }

    public override void CheckLevel()
    {

    }

    public override void Display()
    {

    }

    public void LightSwitch()
    {
        _isOn = !_isOn;
    }

    public void ScheduleLights()
    {
        
    }

    Lights(float low, float high) : base(low, high)
    {
        
    }
}