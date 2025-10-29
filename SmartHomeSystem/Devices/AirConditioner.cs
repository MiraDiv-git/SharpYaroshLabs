using SmartHomeSystem.Interfaces;

namespace SmartHomeSystem.Devices;

public class AirConditioner : Device, IEnergyConsumer
{
    public string DeviceName => Name;
    public int PowerConsumption { get; }

    public AirConditioner(string deviceName)
    {
        Name = deviceName;
        PowerConsumption = 2000;
    }

    public AirConditioner()
    {
        Name = "Безіменний повітрянний кондиціонер";
        PowerConsumption = 2000;
    }

    public override void TurnOn()
    {
        Console.WriteLine($"{Name} почав охолодження.");
        IsOn = true;
    }

    public override void TurnOff()
    {
        Console.WriteLine($"{Name} зупинено.");
        IsOn = false;
    }

    public double GetEnergyUsage(int hours)
    {
        double energy = PowerConsumption * hours / 1000.0;
        return IsOn ? energy : 0;
    }
}