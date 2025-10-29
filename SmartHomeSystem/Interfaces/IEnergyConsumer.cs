namespace SmartHomeSystem.Interfaces;

public interface IEnergyConsumer
{
    string DeviceName { get; }
    int PowerConsumption { get; } // Потрєблєніє = потужність
    double GetEnergyUsage(int hours); 
    //{
    //  double energy = PowerConsumption * hours / 1000
    //  if (!ISwitchable.IsOn) return 0;
    // }
}