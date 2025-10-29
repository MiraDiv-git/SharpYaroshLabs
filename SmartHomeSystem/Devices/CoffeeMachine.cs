using SmartHomeSystem.Interfaces;

namespace SmartHomeSystem.Devices;

public class CoffeeMachine : Device, IEnergyConsumer
{
    public string DeviceName => Name;
    public int PowerConsumption { get; }

    public CoffeeMachine(string deviceName)
    {
        Name = deviceName;
        PowerConsumption = 1000;
    }

    public CoffeeMachine()
    {
        Name = "Безіменна кавова машина";
        PowerConsumption = 1000;
    }

    public override void TurnOn()
    {
        Console.WriteLine($"{Name} почала готувати каву.");
        IsOn = true;
    }

    public override void TurnOff()
    {
        Console.WriteLine($"{Name} завершила роботу.");
        IsOn = false;
    }

    public double GetEnergyUsage(int hours)
    {
        double energy = PowerConsumption * hours / 1000.0;
        return IsOn ? energy : 0;
    }
}