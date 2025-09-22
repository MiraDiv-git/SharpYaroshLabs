// Дико вибачаюсь за джава-стиль
namespace Task1;

public class Program
{
    private static string success_message = "\nЗа дверима знаходилось надзвичайно казкове місце." + 
                                "\nПобачивши знак \"Запоріжжя\" я зрозумів, що я знайшов своє щастя!..\n\nGood Ending";

    private string denial_message = "\nСхоже, що я ніколи не знайду своє щастя...\n\nBad Ending";
    
    public static void Main()
    {
        JustDoIt();
    }
    
    public static bool IsEven(int number)
    {
        return number % 2 == 0;
    }
    
    public static string GetMessage(int number)
    {
        if (IsEven(number))
            return "Двері відкриваються!";
        else
            return "Двері зачинені...";
    }
    
    public static void JustDoIt()
    {
        Console.Clear();
            
        Console.WriteLine("Я опинився перед металевими роздвижними дверима.\nПоряд з ними була панель із кодовим замком...");
            
        Console.Write("\nВвести число >>> ");
        string input = Console.ReadLine();
            
        if (int.TryParse(input, out int x))
        {
            Console.WriteLine(GetMessage(x));
        }
        else
        {
            Console.WriteLine("На превеликий жаль, панель сприймає тільки числа");
            Console.ReadKey();
            JustDoIt();
        }
            
        Console.ReadKey();
    }
}