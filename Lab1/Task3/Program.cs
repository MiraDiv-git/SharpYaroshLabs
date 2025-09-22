// Виправлений код з правильною логікою класифікації віку
namespace Task3;

public class Program
{
    public static void Main()
    {
        Console.Clear();
        
        Console.WriteLine("Обернувшись до цього шляху, переді мною став старець із примітивною дерев'яною милицею.\nВін спитав про мій вік. Варто мені збрехати чи відповісти чесно?");
        Console.Write("\nСказати вік >>> ");
        
        string input = Console.ReadLine();
        
        Console.WriteLine("\nСтарець послухав мене, нахиливши голову, ніби з невеликою скепсисом.\nАж потім він сказав: ");
        int age = int.TryParse(input, out int result) ? result : 0;
        Console.WriteLine("\"" + ClassifyAge(age) + "\"");

        if (age >= 18 && age < 59)
        {
            Console.WriteLine("\n\nGood Ending");
        }
        else
        {
            Console.WriteLine("\n\nBad Ending");
        }

        Console.ReadKey();
    }
    
    public static string ClassifyAge(int age)
    {
        if (age < 0 || age > 120)
        {
            return "Нереальний вік";
        }
        else if (age < 12)
        {
            return "Ви дитина";
        }
        else if (age >= 12 && age <= 17)
        {
            return "Підліток";
        }
        else if (age >= 18 && age <= 59)
        {
            return "Дорослий";
        }
        else
        {
            return "Пенсіонер";
        }
    }
}