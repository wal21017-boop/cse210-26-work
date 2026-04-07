using System.ComponentModel;
using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;

public class Greenhouse
{
    private string _name;
    private int _days = 0;
    private float _height = 0;
    private float _width = 0;
    private float _length = 0;
    private float _area = 0;
    private List<Container> _containers = new List<Container>();
    private List<Device> _devices = new List<Device>();

    private void CalculateFloorArea()
    {
        _area = _width * _length;
    }

    public void AddDevice(string hold)
    {
        float low = float.Parse(Console.ReadLine());
        float high = float.Parse(Console.ReadLine());
        string flowType = Console.ReadLine();
        Device device = hold switch
        {
            "ph" => new PhTester(low, high),
            "humid" => new Humidifier(low, high),
            "water" => new Hose(low, high, flowType),
            "temp" => new Thermostat(low,high),
            "nutrient" => new NutrientDispenser(low, high),
            _ => throw new Exception("Device type was not recognized")


        };

        _devices.Add(device);
    }

    public void AddContainer(string type, string location, float shade, float measure1, float measure2, int number)
    {
        if (_area > 0)
        {
            Container container;
            if (type == "pot")
            {
                float depth = measure1;
                float radius = measure2;
                container = new Pot(location, shade, depth, radius, number);
            }
            else
            {
                float length = measure1;
                float width = measure2;
                container = new Plot(location,shade, length, width, number);
                float area = length*width;
                _area -= area;
                if (_area < 0)
                    {
                        Console.WriteLine($"ERROR: the {_name} greenhouse does not have enough space for this plot");
                        return;
                    }
            }
            _containers.Add(container);
        }
        else
        {
             Console.WriteLine($"ERROR: the {_name} greenhouse does not have any space left");
        }

    }

    public void LoadGreenhouse()
    {
        {
        string filename = $"{_name}.txt";
        string[] all = System.IO.File.ReadAllLines(filename);
        int spot = 0;
        foreach (string parts in all)
        {
            
            string [] myparts = parts.Split("~");
            
            if (myparts[spot] == "Plot")
            {
                int number = int.Parse(myparts[spot + 1]);
                string location = myparts[spot + 2];
                float shade = float.Parse(myparts[spot + 3]);
                float length = float.Parse(myparts[spot + 4]);
                float width = float.Parse(myparts[spot + 5]);
                bool occupied = bool.Parse(myparts[spot + 6]);
                Plot plot = new Plot(location, shade, length, width, number);

                if (occupied)
                    {
                        for(int i = 6; i < 1000; i++)
                        {
                            if (myparts[spot + i] == "Plant")
                            {
                                string plantName = myparts[spot + i + 1];
                                plot.AddPlant(plantName);
                            }
                            else if (myparts[spot + i] == "Device")
                            {
                                string DeviceName = myparts[spot + i + 1];
                                plot.AddDevice(DeviceName);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                _containers.Add(plot);

            }
            else if (myparts[spot] == "Pot")
            {
                int number = int.Parse(myparts[spot + 1]);
                string location = myparts[spot + 2];
                float shade = float.Parse(myparts[spot + 3]);
                float depth = float.Parse(myparts[spot + 4]);
                float radius = float.Parse(myparts[spot + 5]);
                bool occupied = bool.Parse(myparts[spot + 6]);
                Pot pot = new Pot(location, shade, depth, radius, number);
                if (occupied)
                    {
                        for(int i = 6; i < 100; i++)
                        {
                            
                            if (myparts[spot + i] == "Plant")
                                {
                                    pot.LoadPlant(myparts[spot + i + 1], myparts[spot + i + 2], myparts[spot+i+3], myparts[spot+i+4]);
                                    
                                }
                                else if (myparts[spot + i] == "Device")
                                {
                                    
                                    pot.LoadDevice(myparts[spot + i + 1], myparts[spot + i + 2], myparts[spot+i+3], myparts[spot+i+4], myparts[spot+i+5], myparts[spot+i+6]);
                                    
                                }
                        }
                    }
                _containers.Add(pot);

            }
            else if (myparts[spot] == "Greenhouse")
            {
                _days = int.Parse(myparts[spot + 1]);
                _height = float.Parse(myparts[spot + 2]);
                _width = float.Parse(myparts[spot + 3]);
                _length= float.Parse(myparts[spot + 4]);
                _area = float.Parse(myparts[spot + 5]);
                
            }
            else
            {
                Console.WriteLine("--WARNING--");
                Console.WriteLine("The file may have been corrupted, some data was not saved in a way that the program can recognize it");
            }
        }
    }
    }

    public void SaveGreenhouse()
    {
        string filename = $"{_name}.txt";
        using (StreamWriter outputFile =  new StreamWriter(filename))
        {
            outputFile.WriteLine($"{"Greenhouse"}~{_days}~{_height}~{_width}~{_length}~{_area}~");
            foreach (Container container in _containers)
            {
                
                outputFile.WriteLine(container.Save());
        
            }
        }
    }

    public Greenhouse(string name, float length, float width, float height)
    {
        _name = name;
        _height = height;
        _width = width;
        _length = length;
        CalculateFloorArea();
    }

    // public void TakeCareOfPlants()
    // {
        
    // }

    public void Display()
    {
        foreach (Container container in _containers)
        {
            container.Display();
        }

        foreach (Device device in _devices)
        {
            device.Display();
        }
        
    }

    public Greenhouse(string name)
    {
        _name = name;
    }

    public void NextDay()
    {
        _days+=1;
        foreach (Container container in _containers)
        {
            container.NextDay();
        }

        foreach (Device device in _devices)
        {
            device.NextDay();
        }
    }

    public void AddPlant(int containerNum, string plantName)
    {
        _containers[containerNum+1].AddPlant(plantName);
    }

    public int NumContainers()
    {
        return _containers.Count;
    }
}