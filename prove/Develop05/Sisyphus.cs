public class Sisyphus : Goal
{
    private int _numTimesCompleted = 0;
    public override int AddPoints()
    {
        _isComplete = false;
        _numTimesCompleted +=1;
        return _numPoints;
    }
    public Sisyphus(string name, string description, 
    int numPoints, bool isComplete, 
    int numTimesCompleted) : base(name, description, numPoints, isComplete)
    {
        _numTimesCompleted = numTimesCompleted;
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"{_name}: {_description}");
        Console.WriteLine($"This goal has been completed {_numTimesCompleted} times");
        Console.WriteLine($"There are still \u221E points still available for this goal, worth {_numPoints} per completion");
        Console.WriteLine("This goal has not been finished. Please continue trying to finish this goal.");
    
    }
    public override void GiveUp()
    {   
        int considerTime = 1;
        string yn = "y";
        do{
            Thread.Sleep(considerTime);
            considerTime += 1000;
            Console.WriteLine("Are you sure you want to give up on this goal?");
            Console.Write("Enter y for yes or n for no ");
            yn = Console.ReadLine();
        } while (yn == "y");        
        Console.WriteLine("It seems you have chosen to continue to working towards your goal");
        Thread.Sleep(1000);
        Console.WriteLine("Good choice");
    }
    public override string SaveGoal()
    {
        return $"{nameof(Sisyphus)}~{_name}~{_description}~{_numPoints}~{_isComplete}~{_numTimesCompleted}~";
    }
    public override void CreateGoal()
    {
        base.CreateGoal();
    }
    
    public Sisyphus() : base(){}
}