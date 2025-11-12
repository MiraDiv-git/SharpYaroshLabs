using RestaurantOrderSystem.Enums;

namespace RestaurantOrderSystem.Interfaces;

public interface IMenuItem
{
    string Name { get; }
    string? Description { get; }
    Categories Category { get; }
    decimal Price { get; }
}