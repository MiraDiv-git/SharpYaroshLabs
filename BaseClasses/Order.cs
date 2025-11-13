using RestaurantOrderSystem.Enums;
using RestaurantOrderSystem.Interfaces;

namespace RestaurantOrderSystem.BaseClasses;

public class Order
{
    private static int nextId = 1;
    private OrderManager manager;
    public int Id { get; init; }
    public DateTime Date { get; init; }
    public OrderStatus Status { get; init; }
    private List<IMenuItem> Items => manager.menu.Foods.Cast<IMenuItem>().Concat(manager.menu.Drinks).ToList();

    public Order(DateTime date, OrderStatus status)
    {
        Id = nextId++;
        Date = date;
        Status = status;
    }
    

    public void PrintOrder()
    {
        Items;
        // Я ебал блять я не знаю как это реализовать
    }
}