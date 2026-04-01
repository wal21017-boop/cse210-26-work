public class PhTester : Device
{
    private static Random random = new Random();
    private float _currentPh = random.NextSingle() * 14;
    private Dictionary<string, float> _phStores = new Dictionary<string, float>{{"lime", 0}, {"sulfur", 0}};

    public override void CheckLevel()
    {

    }

    public override void Alert()
    {

    }

    public override void Display()
    {
        Console.WriteLine(_currentPh);
    }

    public void AddLime()
    {
        if (_phStores["lime"] > 0 && _currentPh > _highThreshold)
        {
            _currentPh +=1;
            _phStores["lime"] -= 1;
        }
        else
        {
            Console.WriteLine("Please add more lime to this PhTester");
        }
    }

    public void AddSulfur()
    {
        if (_phStores["sulfur"] > 0 && _currentPh < _lowThreshold)
        {
            _currentPh -=1;
            _phStores["sulfur"] -= 1;
        }
        else
        {
            Console.WriteLine("Please add more lime to this PhTester");
        }
    }

    public PhTester(float low, float high) : base(low, high)
    {
        
    }
}