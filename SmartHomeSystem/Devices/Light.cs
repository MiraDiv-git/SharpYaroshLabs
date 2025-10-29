using SmartHomeSystem.Interfaces;

namespace SmartHomeSystem.Devices;

public class Light : Device, IEnergyConsumer
{
    public string DeviceName => Name;
    public int PowerConsumption { get; }

    public Light(string deviceName)
    {
        Name = deviceName;
        PowerConsumption = 60;
    }

    public Light()
    {
        Name = "Безіменне джерело світла";
        PowerConsumption = 60;
    }

    public override void TurnOn()
    {
        Console.WriteLine($"{Name} засвітилася.");
        IsOn = true;
    }

    public override void TurnOff()
    {
        Console.WriteLine($"{Name} вимкнена.");
        IsOn = false;
    }

    public double GetEnergyUsage(int hours)
    {
        double energy = PowerConsumption * hours / 1000.0;
        return IsOn ? energy : 0;
    }
}