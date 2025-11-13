using RestaurantOrderSystem.BaseClasses;
using RestaurantOrderSystem.Enums;
using RestaurantOrderSystem.Interfaces;

namespace RestaurantOrderSystem;

public class OrderManager
{
    private List<Order> _orders = new();

    public void CreateOrder(Order order)
    {
        _orders.Add(order);
    }

    public void ChangeOrderStatus(int orderId, OrderStatus status)
    {
        var order = _orders.FirstOrDefault(o => o.Id == orderId);
        if (order != null)
        {
            order.Status = status;
        }
    }
    
    public Order? GetOrder(int orderId)
    {
        return _orders.FirstOrDefault(o => o.Id == orderId);
    }

    public void AddItemToOrder(int orderId, IMenuItem mi)
    {
        var order = _orders.FirstOrDefault(o => o.Id == orderId);
        if (order != null)
        {
            order.AddItem(mi);
        }
    }

    public void PrintOrder(int orderId)
    {
        var order = _orders.FirstOrDefault(o => o.Id == orderId);
        if (order != null)
        {
            order.PrintOrder();
        }
    }

    public void PrintAllOrders()
    {
        foreach (var order in _orders)
        {
            order.PrintOrder();
        }
    }
}