using System.ComponentModel;
using System.Formats.Asn1;
using System.Reflection.Emit;
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
        float low = 0;
        float high = 0;
        if (hold == "humid" || hold == "temp")
        {
            Console.WriteLine("What is the lowest value this device should allow before automatically working?");
            low = float.Parse(Console.ReadLine());
            Console.WriteLine("What is the highest value this device should allow before automatically working?");
            high = float.Parse(Console.ReadLine());
        }
        else if (hold == "lights")
        {
            Console.WriteLine("What is the minimum number of hours this device should be on each day?");
            low = float.Parse(Console.ReadLine());
            Console.WriteLine("What is the maximum number of hours this device should be on each day?");
            high = float.Parse(Console.ReadLine());
        }
        else
        {
            low = 0;
            high = 0;
        }
       
        string flowType = "";
        if (hold == "water")
        {
            Console.WriteLine("How should the hose water onto the plant? ");
            Console.WriteLine("Accepted Values: drip, flood, rain, stream");
            flowType = Console.ReadLine();
        }
        Device device = hold switch
        {
            "ph" => new PhTester(low, high),
            "humid" => new Humidifier(low, high),
            "water" => new Hose(low, high, flowType),
            "temp" => new Thermostat(low,high),
            "nutrient" => new NutrientDispenser(low, high),
            "lights" => new Lights(low, high),
            _ => throw new Exception("Device type was not recognized")


        };

        _devices.Add(device);
    }

    public void AddContainer(string type, string location, float shade, float measure1, float measure2, int number)
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
                
            }
            _containers.Add(container);
        }
        

    

    public void LoadGreenhouse()
    {
        {
        string filename = $"{_name}.txt";
        string[] all = System.IO.File.ReadAllLines(filename);
        int spot = 0;
        foreach (string parts in all)
        {
            spot = 0;
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
                spot += 7;

                if (occupied)
                    {
                        for(int i = 0; i < 1000; i++)
                        {
                            if (myparts[spot + i] == "Plant")
                            {
                                string plantName = myparts[spot + i + 1];
                                plot.LoadPlant(plantName, myparts[spot + i +2], myparts[spot + i + 3], myparts[spot + i + 4]);
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
                spot +=7;
                Pot pot = new Pot(location, shade, depth, radius, number);
                if (occupied)
                    {
                        for(int i = 0; i + spot < myparts.Length; i++)
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
                spot +=6;
                
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
        Console.WriteLine($"{_name} greenhouse saved!");
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
        Console.WriteLine($"Day {_days}");
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
        _containers[containerNum-1].AddPlant(plantName);
        Console.WriteLine($"{plantName} plant added");
        Console.WriteLine("Would you like to add any devices to automatically monitor the plant? (y/n) ");
        string yn = Console.ReadLine();
        if (yn == "y")
        {
            int nutrient = 0;
            int hose = 0;
            int ph = 0;
            do 
            {
                Console.WriteLine("Choose a device");
                Console.WriteLine("1: Nutrient Dispenser");
                Console.WriteLine("2: Automatic Hose");
                Console.WriteLine("3: pH Tester");
                int device = int.Parse(Console.ReadLine());
                if (device == 1 && nutrient == 0)
                {
                    _containers[containerNum-1].AddDevice("nutrient");
                    nutrient = 1;
                }
                else if (device == 2 && hose == 0)
                {
                    _containers[containerNum-1].AddDevice("water");
                    hose = 1;
                }
                else if (device == 3 && ph == 0)
                {
                    _containers[containerNum-1].AddDevice("ph");
                    ph = 1;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                    Console.WriteLine("You may only have one device of each type");
                }
                Console.WriteLine("Would you like to add another device? (y/n)");
                yn = Console.ReadLine();
            } while (yn == "y");
        }
    }

    public int NumContainers()
    {
        return _containers.Count;
    }

    public void CheckDevices()
    {
        foreach (Device device in _devices)
        {
            device.CheckLevel();
        }
        foreach (Container container in _containers)
        {
            container.CheckDevices();
        }
    }
}