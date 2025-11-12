namespace RestaurantOrderSystem.Interfaces;

public interface IDrinkable
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Category { get; set; }
    public int DrinkLitrage { get; set; }
    public float AlcoholPercentage { get; set; }
    public decimal Price { get; set; }
}