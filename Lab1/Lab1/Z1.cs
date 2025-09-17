namespace lab1;

public class Z1
{
    static bool IsEven(int number)
    {
        return number % 2 == 0;
    }
    public static void JustDoIt()
    {
        Console.Clear();
            
        Console.WriteLine("Я опинився перед металевими роздвижними дверима.\nПоряд з ними була панель із кодовим замком...");
            
        Console.Write("\nВвести число >>> ");
        string input = Console.ReadLine();
            
        if (int.TryParse(input, out int x))
        {
            if (IsEven(x))
            {
                Console.WriteLine("\nДвері відчіняються...\nЗа дверима знаходилось надзвичайно казкове місце. \nПобачивши знак \"Запоріжжя\" я зрозумів, що я знайшов своє щастя!..\n\nGood Ending");
            }
            else
            {
                Console.WriteLine("\nДвері так і залишились закритими... \nСхоже, що я ніколи не знайду своє щастя...\n\nBad Ending");
            }
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