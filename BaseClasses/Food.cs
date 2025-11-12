using RestaurantOrderSystem.Enums;
using RestaurantOrderSystem.Interfaces;

namespace RestaurantOrderSystem.BaseClasses;

public class Food : IEatable
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public Categories Category { get; set; }
    public int PortionSize { get; set; }
    public decimal Price { get; set; }

    public Food(string name, string? description, Categories category, int portionSize, decimal price)
    {
        Name = name;
        Description = description;
        Category = category;
        PortionSize = portionSize;
        Price = price;
    }
}