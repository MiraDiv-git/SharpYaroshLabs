using SmartHomeSystem.Devices;

namespace SmartHomeSystem;

class Program
{
    static void Main()
    {
        SmartHomeController controller = new SmartHomeController();
        
        Light lamp = new Light();
        controller.AddDevice(lamp);
        controller.AddEnergyDevice(lamp);
        
        AirConditioner cond = new AirConditioner();
        controller.AddDevice(cond);
        controller.AddEnergyDevice(cond);
        
        CoffeeMachine cof = new CoffeeMachine();
        controller.AddDevice(cof);
        controller.AddEnergyDevice(cof);
        
        MotionSensor observer = new MotionSensor();
        controller.AddDevice(observer);
        
        
        
        controller.TurnAllOn();
        
        lamp.PrintStatus();
        cond.PrintStatus();
        cof.PrintStatus();
        observer.PrintStatus();
        
        controller.ShowEnergyReport(5);
        
        controller.TurnAllOff();
    }
}