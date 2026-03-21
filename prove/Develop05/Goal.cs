public abstract class Goal
{
    protected string _name = "";
    protected string _description = "";
    protected int _numPoints = 0;
    protected bool _isComplete = false;
    public Goal(string name, string description, int numPoints, bool isComplete)
    {
        _name = name;
        _description = description;
        _numPoints = numPoints;
        _isComplete = isComplete;
    }
    public virtual int AddPoints()
    {
        if (_isComplete == false)
        {
            _isComplete = true;
            return _numPoints;
        }
        else
        {
            return 0;
        }
    }
    public virtual void GiveUp()
    {
        Console.WriteLine("Disappointing, but oh well. Are you sure you want to give up on this goal?");
        Console.WriteLine("If you do, it will be marked as finished");
        Console.Write("Enter y for yes or n for no ");
        string yn = Console.ReadLine();
        if (yn == "y")
        {
            _isComplete = true;
            Console.WriteLine("Disappointing");
        }
        else
        {
            Console.WriteLine("It seems you have chosen to continue to working towards your goal");
            Console.WriteLine("Good choice");
        }
    }
    public virtual void DisplayGoal()
    {
        Console.WriteLine($"{_name} : {_description}");
        Console.WriteLine($"Worth {_numPoints} points on completion");
        if (_isComplete == true)
        {
            Console.WriteLine("Goal completed!");
        }
        
    }
    public virtual string SaveGoal()
    {
        return $"{nameof(SimpleGoal)}~{_name}~{_description}~{_numPoints}~{_isComplete}~";
    }

    public virtual void CreateGoal()
    {
        Console.WriteLine("What name would you like to give the goal?");
        _name = Console.ReadLine();
        Console.WriteLine("Give a description of your goal");
        _description = Console.ReadLine();
        Console.WriteLine("How many points is your goal worth when completed once? ");
        _numPoints = int.Parse(Console.ReadLine());
    }

    public void ShortDisplayGoal()
    {
        Console.WriteLine($"{_name} : {_description}");
    }

    public Goal(){}
}