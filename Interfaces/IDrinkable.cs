using RestaurantOrderSystem.Enums;

namespace RestaurantOrderSystem.Interfaces;

public interface IDrinkable
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public Categories Category { get; set; }
    public float DrinkLitrage { get; set; }
    public int? AlcoholPercentage { get; set; }
    public decimal Price { get; set; }
}