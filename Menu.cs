using RestaurantOrderSystem.BaseClasses;

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
   private readonly List<Food> _foods = new();

   public void AddFood(Food food)
   {
      _foods.Add(food);
   }
   
   public void PrintMenu()
   {
      var grouped = _foods
         .GroupBy(f => f.Category)
         .OrderBy(g => g.Key);
      
      foreach (var categoryGroup in grouped)
      {
         Console.WriteLine($"\n=== {categoryGroup.Key.ToFriendlyString()} ===");
         
         foreach (var food in categoryGroup.OrderBy(f => f.Name))
         {
            Console.WriteLine($"\n{food.Name} - {food.PortionSize}g | {food.Price:C}");
            if (!string.IsNullOrWhiteSpace(food.Description))
               Console.WriteLine($"Description: {food.Description}");
         }
      }
   }
}