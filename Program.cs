using RestaurantOrderSystem.BaseClasses;
using RestaurantOrderSystem.Enums;
using System.Globalization;

namespace RestaurantOrderSystem;

class Program
{
    static void Main(string[] args)
    {
        CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("uk-UA");
        CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("uk-UA");

        Demo.Run();
    }
}