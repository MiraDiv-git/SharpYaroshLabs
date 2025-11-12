using RestaurantOrderSystem.Enums;

namespace RestaurantOrderSystem.Interfaces;

public interface IEatable
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public Categories Category { get; set; }
    public int PortionSize { get; set; }
    public decimal Price { get; set; }
}