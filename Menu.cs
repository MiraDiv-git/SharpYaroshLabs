using RestaurantOrderSystem.BaseClasses;
using RestaurantOrderSystem.Interfaces;

namespace RestaurantOrderSystem;

public static class EnumExtensions
{
   public static string ToFriendlyString(this Enum value)
   {
      return string.Concat(value.ToString().Select((c, i) =>
         i > 0 && char.IsUpper(c) ? " " + c : c.ToString()));
   }
}

public class Menu
{
   public List<Food> Foods = new();
   public List<Drink> Drinks = new();

   public void AddFood(Food food)
   {
      Foods.Add(food);
      Console.WriteLine($"Успішно додано нову страву: {food.Name}");
   }

   public void AddDrink(Drink drink)
   {
      Drinks.Add(drink);
      Console.WriteLine($"Успішно додано новий напій: {drink.Name}");
   }
   
   public void PrintMenu()
   {
      var allItems = Foods.Cast<IMenuItem>()
         .Concat(Drinks)
         .GroupBy(item => item.Category)
         .OrderBy(g => g.Key);
   
      Console.WriteLine("\n\nРесторан \"Хтивий Краб\"\n\n====== МЕНЮ ======");
      foreach (var categoryGroup in allItems)
      {
         Console.WriteLine($"\n=== {categoryGroup.Key.ToFriendlyString()} ===");
      
         foreach (var item in categoryGroup.OrderBy(i => i.Name))
         {
            Console.Write($"\n{item.Name} - ");
         
            if (item is Food food)
               Console.Write($"{food.PortionSize} г");
            else if (item is Drink drink)
               Console.Write($"{drink.DrinkLitrage} мл");
            
            Console.Write($" | {item.Price:C}");
         
            if (item is Drink d)
            {
               if (d.AlcoholPercentage.HasValue)
                  Console.Write($" | Алкоголь: {d.AlcoholPercentage.Value}%");
               else
                  Console.WriteLine();
            }
            
            if (!string.IsNullOrWhiteSpace(item.Description))
               Console.WriteLine($"\n{item.Description}");
            else
               Console.WriteLine();
         }
      }
   }
}