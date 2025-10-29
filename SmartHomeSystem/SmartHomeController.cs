using SmartHomeSystem.Interfaces;

namespace SmartHomeSystem;

public class SmartHomeController
{
    public List<ISwitchable> deviceList { get; set; } = new List<ISwitchable>();
    public List<IEnergyConsumer> energyDeviceList { get; set; } = new List<IEnergyConsumer>();
    
    public void AddDevice(ISwitchable device)
    {
        deviceList.Add(device);
    }

    public void AddEnergyDevice(IEnergyConsumer device)
    {
        energyDeviceList.Add(device);
    }

    public void TurnAllOn()
    {
        foreach (var device in deviceList)
        {
            device.TurnOn();
        }
    }

    public void TurnAllOff()
    {
        foreach (var device in deviceList)
        {
            device.TurnOff();
        }
    }

    public void ShowEnergyReport(int hours)
    {
        var culture = new System.Globalization.CultureInfo("uk-UA");
        Console.WriteLine($"Звіт про споживання енергії за {hours} год:");
    
        double totalEnergy = 0;
    
        foreach (var device in energyDeviceList)
        {
            double energy = device.GetEnergyUsage(hours);
            Console.WriteLine($"{device.DeviceName}: {energy.ToString("F2", culture)} кВт·год (потужність: {device.PowerConsumption} Вт)");
            totalEnergy += energy;
        }
    
        Console.WriteLine($"Загальне споживання: {totalEnergy.ToString("F2", culture)} кВт·год");
        Console.WriteLine($"Вартість (~4 грн/кВт·год): {(totalEnergy * 4).ToString("F2", culture)} грн");
    }
}