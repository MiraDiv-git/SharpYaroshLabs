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
        
        menu.AddDrink(new Drink(
            "Coca-Cola",
            null,
            Categories.SoftDrinks,
            0.5f,
            null,
            40m));
        
        menu.AddDrink(new Drink(
            "Jägermeister",
            "Drink for real German man!",
            Categories.Spirits,
            0.75f,
            35,
            820.35m));
        
        menu.AddDrink(new Drink(
            "Nemiroff",
            "Classic ukrainian vodka. Tastes better with borscht",
            Categories.Spirits,
            0.7f,
            40,
            180.89m));
        
        menu.PrintMenu();
    }
}