namespace SmartHomeSystem.Devices;

public class MotionSensor : Device
{
    public override string Name { get; set; } = "Датчик руху у коридорі";

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