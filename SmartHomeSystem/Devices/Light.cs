using SmartHomeSystem.Interfaces;

namespace SmartHomeSystem.Devices;

public class Light : Device, IEnergyConsumer
{
    public override string Name { get; set; } = "Лампа у вітальні";
    public string DeviceName => Name;
    public int PowerConsumption { get; } = 60;

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