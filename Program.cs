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
        
        Menu menu = new Menu();
        
        menu.AddFood(new Food(
            "Ukrainian Borscht",
            "Classic beetroot soup originally made in Ukraine. Served with sour cream and pampushka",
            Categories.HotDishes,
            250,
            39.99m
        ));
        
        menu.PrintMenu();
    }
}