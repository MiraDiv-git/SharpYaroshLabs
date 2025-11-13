using RestaurantOrderSystem.Enums;
using RestaurantOrderSystem.Interfaces;

namespace RestaurantOrderSystem.BaseClasses;

public class Order
{
    private static int nextId = 1;
    private List<IMenuItem> Items = new();
    private OrderManager manager;
    private decimal totalPrice = 0m;
    
    public int Id { get; init; }
    public DateTime Date { get; init; }
    public OrderStatus Status { get; set; }

    public Order(DateTime date)
    {
        Id = nextId++;
        Date = date;
        Status = OrderStatus.Обробляється;
    }

    public void AddItem(IMenuItem item)
    {
        Items.Add(item);
        totalPrice += item.Price;
    }

    public void PrintOrder()
    {
            Console.WriteLine($"\n=== Замовлення №{Id} ===\n" 
                              + $"== Статус: {Status.ToString()}\n" 
                              + new string('_', 40));
            
            foreach (var item in Items)
                Console.WriteLine($"{item.Name} - {item.Price:C}");
            
            Console.WriteLine($"\nУсього: {totalPrice:C}\n" + new string('¯', 40));
    }
}