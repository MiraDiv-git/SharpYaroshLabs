using RestaurantOrderSystem.Interfaces;
using RestaurantOrderSystem.Enums;

namespace RestaurantOrderSystem.BaseClasses;

public class Drink : IDrinkable, IMenuItem
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public Categories Category { get; set; }
    public float DrinkLitrage { get; set; }
    public int? AlcoholPercentage { get; set; }
    public decimal Price { get; set; }

    public Drink(string name, string? description, Categories category, float drinkLitrage, int? alcoholPercentage, decimal price)
    {
        Name = name;
        Description = description;
        Category = category;
        DrinkLitrage = drinkLitrage;
        AlcoholPercentage = alcoholPercentage;
        Price = price;
    }
}