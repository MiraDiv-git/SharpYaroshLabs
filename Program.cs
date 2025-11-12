using RestaurantOrderSystem.BaseClasses;
using RestaurantOrderSystem.Enums;
using System.Globalization;
using RestaurantOrderSystem.Interfaces;

namespace RestaurantOrderSystem;

class Program
{
    static void Main(string[] args)
    {
        CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("uk-UA");
        CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("uk-UA");

        DoMenu();
    }

    static void DoMenu()
    {
        Menu menu = new Menu();
        
        menu.AddFood(new Food(
            "Український борщ",
            "Класичний суп з буряка, зроблений в Україні. Подається зі сметаною та пампушками",
            Categories.ГарячіСтрави,
            250,
            39.99m
        ));
        
        menu.AddDrink(new Drink(
            "Coca-Cola",
            null,
            Categories.БезалкогольніНапої,
            0.5f,
            null,
            40m));
        
        menu.AddDrink(new Drink(
            "Jägermeister",
            "Напій для справжніх німецьких чоловіків!",
            Categories.МіцніНапої,
            0.75f,
            35,
            820.35m));
        
        menu.AddDrink(new Drink(
            "Nemiroff",
            "Класична українська горілка. Краще смакує з борщем.",
            Categories.МіцніНапої,
            0.7f,
            40,
            180.89m));
        
        menu.PrintMenu();
    }
}