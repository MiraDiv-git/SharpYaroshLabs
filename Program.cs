using RestaurantOrderSystem.BaseClasses;
using RestaurantOrderSystem.Enums;

namespace RestaurantOrderSystem;

class Program
{
    static void Main(string[] args)
    {
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