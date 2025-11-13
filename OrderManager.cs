using RestaurantOrderSystem.BaseClasses;
using RestaurantOrderSystem.Interfaces;

namespace RestaurantOrderSystem;

public class OrderManager
{
    public Menu menu;
    private List<Order> _orders = new();
    private int _nextOrderId = 1;
    
    public OrderManager(Menu ormanMenu)
    {
        menu = ormanMenu;
    }

    public void CreateOrder(Order order)
    {
        _orders.Add(order);
    }

    public void PrintAllOrders()
    {
        foreach (var order in _orders)
        {
            Console.WriteLine(order);
        }
    }
}