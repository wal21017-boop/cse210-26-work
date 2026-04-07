public class PhTester : Device
{
    private static Random random = new Random();
    private float _currentPh = random.NextSingle() * 14;
    private Dictionary<string, float> _phStores = new Dictionary<string, float>{{"lime", 0}, {"sulfur", 0}};

    public override void CheckLevel()
    {
        AddLime();
        AddSulfur();
    }

    public override void Alert()
    {
        Console.WriteLine("ERROR: pH tester has failed");
    }

    public override void Display()
    {
        Console.WriteLine($"pH = {_currentPh}");
        Console.WriteLine($"Lime stores = {_phStores["lime"]}");
        Console.WriteLine($"Sulfur stores = {_phStores["sulfur"]}");
        Console.WriteLine($"Would you like to refill the PhTester? (y/n)");
            string yn = Console.ReadLine();
            if (yn == "y")
            {
                _phStores["lime"] = 10;
                _phStores["sulfur"] = 10;
            }
    }

    public void AddLime()
    {
        if (_phStores["lime"] > 0 && _currentPh > _highThreshold)
        {
            _currentPh +=1;
            _phStores["lime"] -= 1;
        }
        else if (_phStores["lime"] <=1)
        {
            Console.WriteLine("There is not enough lime to this PhTester");
            Console.WriteLine($"Would you like to refill the lime? (y/n)");
            string yn = Console.ReadLine();
            if (yn == "y")
            {
                _phStores["lime"] = 10;
            }
        }
    }

    public void AddSulfur()
    {
        if (_phStores["sulfur"] > 0 && _currentPh < _lowThreshold)
        {
            _currentPh -=1;
            _phStores["sulfur"] -= 1;
        }
        else if (_phStores["Sulfur"] <= 1)
        {
            Console.WriteLine("There is not enough sulfur in this PhTester");
            Console.WriteLine($"Would you like to refill the sulfur? (y/n)");
            string yn = Console.ReadLine();
            if (yn == "y")
            {
                _phStores["sulfur"] = 10;
            }
        }
    }

    public PhTester(float low, float high) : base(low, high)
    {
        
    }

    public override void NextDay()
    {
        AddLime();
        AddSulfur();
    }
}