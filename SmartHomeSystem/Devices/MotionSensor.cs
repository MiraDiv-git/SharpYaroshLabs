namespace SmartHomeSystem.Devices;

public class MotionSensor : Device
{
    public MotionSensor(string name)
    {
        Name = name;
    }

    public MotionSensor()
    {
        Name = "Безіменний сенсор руху";
    }

    public override void TurnOn()
    {
        Console.WriteLine($"{Name} активовано.");
        IsOn = true;
    }

    public override void TurnOff()
    {
        Console.WriteLine($"{Name} деактивовано.");
        IsOn = false;
    }
}