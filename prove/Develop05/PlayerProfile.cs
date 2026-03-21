public class PlayerProfile
{
    private int _totalPoints = 0;
    private string _playerName = "";
    private List<Goal> _goals = new List<Goal>();

    public void LoadProfile()
    {
        string filename = $"{_playerName}.txt";
        string[] all_goals = System.IO.File.ReadAllLines(filename);
        int spot = 0;
        foreach (string parts in all_goals)
        {
            
            string [] myparts = parts.Split("~");
            if (myparts[spot] == "Goal")
            {    
                string name = myparts[spot + 1];
                string description = myparts[spot + 2];
                int numPoints = int.Parse(myparts[spot + 3]);
                bool isComplete = bool.Parse(myparts[spot + 4]);
                _goals.Add(new SimpleGoal(name, description, numPoints, isComplete));
                
            }
            else if (myparts[spot] == "ListGoal")
            {
                string name = myparts[spot + 1];
                string description = myparts[spot + 2];
                int numPoints = int.Parse(myparts[spot + 3]);
                bool isComplete = bool.Parse(myparts[spot + 4]);
                int numTimesCompleted = int.Parse(myparts[spot + 5]);
                int checkpoint = int.Parse(myparts[spot + 6]);
                _goals.Add(new ListGoal(name, description, numPoints, isComplete, numTimesCompleted, checkpoint));
                
            }
            else if (myparts[spot] == "Sisyphus")
            {
                string name = myparts[spot + 1];
                string description = myparts[spot + 2];
                int numPoints = int.Parse(myparts[spot + 3]);
                bool isComplete = bool.Parse(myparts[spot + 4]);
                int numTimesCompleted = int.Parse(myparts[spot + 5]);
                _goals.Add(new Sisyphus(name, description, numPoints, isComplete, numTimesCompleted));
                
            }
            else if (myparts[spot] == "PlayerProfile")
            {
                _totalPoints = int.Parse(myparts[spot + 1]);
                _playerName = myparts[spot + 2];
                
            }
            else
            {
                Console.WriteLine("--WARNING--");
                Console.WriteLine("The file may have been corrupted, some data was not saved in a way that the program can recognize it");
            }
        }
    }
    
    public void RecordEvent(int numGoal)
    {
        try
        {
            Goal goal = _goals[numGoal -1];
            _totalPoints += goal.AddPoints();
        }
        catch
        {
            Console.WriteLine("error");
        }

        
        
    }
    public void SaveProfile()
    {
        string filename = $"{_playerName}.txt";
        using (StreamWriter outputFile =  new StreamWriter(filename))
        {
            outputFile.WriteLine($"{nameof(PlayerProfile)}~{_totalPoints}~{_playerName}~");
            foreach (Goal goal in _goals)
            {
                
                outputFile.WriteLine(goal.SaveGoal());
        
            }
        }
        
    }
    public void CreateProfile()
    {
        Console.Write("Please enter your name or an alias: ");
        _playerName = Console.ReadLine();

    }

    public void SetPlayerName(string name)
    {
        _playerName = name;
    }

    public void DisplayProfile()
    {
        Console.WriteLine($"Name : {_playerName}");
        Console.WriteLine($"Current Points : {_totalPoints}");
        int num = 0;
        foreach (Goal goal in _goals)
        {
            num+=1;
            Console.Write($"Goal {num} : ");
            goal.DisplayGoal();
        }

    }
    public void DisplayPoints()
    {
        Console.WriteLine($"Current Points : {_totalPoints}");
    }
    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void AddPoints(int points)
    {
        _totalPoints += points;
        Console.WriteLine($"{points} points added to your total!");
    }

    public void DisplayShortProfile()
    {
        int num = 0;
        foreach (Goal goal in _goals)
        {
            num+=1;
            Console.Write($"Goal {num} : ");
            goal.ShortDisplayGoal();
        }
    }

}