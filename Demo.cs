using RestaurantOrderSystem.BaseClasses;
using RestaurantOrderSystem.Enums;

namespace RestaurantOrderSystem;

public class Demo
{
    public static void Run()
    {
        Menu menu = new Menu();
        
        menu.AddFood(new Food(
            "Український борщ",
            "Класичний суп з буряка, зроблений в Україні. Подається зі сметаною та пампушками",
            Categories.ГарячіСтрави,
            250,
            39.99m
        ));
        
        menu.AddFood(new Food(
            "Картопляне пюре",
            null,
            Categories.ГоловніСтрави,
            300,
            79.99m));
        
        menu.AddFood(new Food(
            "Холодець",
            null,
            Categories.ХолодніСтрави,
            150,
            139.80m));
        
        menu.AddFood(new Food(
            "Сухарики",
            "Сухарики Flint зі смаком томату. Ми не маємо ліцензії на продаж",
            Categories.Закуски,
            70,
            60m));
        
        menu.AddFood(new Food(
            "Тірамісу",
            null,
            Categories.Десерти,
            120,
            85.35m));
        
        menu.AddDrink(new Drink(
            "Coca-Cola",
            null,
            Categories.БезалкогольніНапої,
            0.5f,
            null,
            40m));
        
        menu.AddDrink(new Drink(
            "Scotty West: Black Stout",
            "Дуже смачне темне крафтове пиво. Власник ресторану рекомендує.",
            Categories.Пиво,
            0.75f,
            5,
            62.95m));
        
        menu.AddDrink(new Drink(
            "Koblevo",
            null,
            Categories.Вино,
            0.5f,
            12,
            98.32m));
        
        menu.AddDrink(new Drink(
            "Nemiroff",
            "Класична українська горілка. Краще смакує з борщем.",
            Categories.МіцніНапої,
            0.7f,
            40,
            180.89m));
        
        menu.PrintMenu();

        OrderManager om = new OrderManager();
        om.CreateOrder(new Order(DateTime.Now));
        om.CreateOrder(new Order(DateTime.Now));
        om.CreateOrder(new Order(DateTime.Now));
        
        om.AddItemToOrder(1, menu.Foods[4]);
        om.AddItemToOrder(1, menu.Drinks[0]);
        
        om.AddItemToOrder(2, menu.Drinks[1]);
        om.AddItemToOrder(2, menu.Drinks[1]);
        om.AddItemToOrder(2, menu.Drinks[1]);
        om.AddItemToOrder(2, menu.Drinks[1]);
        om.AddItemToOrder(2, menu.Foods[3]);
        om.AddItemToOrder(2, menu.Foods[3]);
        
        om.AddItemToOrder(3, menu.Drinks[3]);
        om.AddItemToOrder(3, menu.Foods[0]);
        
        om.PrintAllOrders();
        
        om.ChangeOrderStatus(2, OrderStatus.Готується);
        om.PrintOrder(2);
    }
}