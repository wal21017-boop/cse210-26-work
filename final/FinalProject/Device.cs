public abstract class Device
{
    protected float _lowThreshold = 0;
    protected float _highThreshold = 0;
    protected bool _isOn = false;

    public abstract void CheckLevel();
    public abstract void Alert();
    public abstract void Display();

    public void FlipSwitch()
    {
        _isOn = !_isOn;
    }

    public Device(float low, float high)
    {
        _lowThreshold = low;
        _highThreshold = high;
    }

    public abstract void NextDay();
    public abstract string Save();
}