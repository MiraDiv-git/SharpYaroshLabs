// Дико вибачаюсь за джава-стиль
namespace Task3;

public class Program
{
    public static void Main()
    {
        Console.Clear();
        
        Console.WriteLine("Обернувшись до цього шляху, переді мною став старець із примітивною дерев'яною милицею.\nВін спитав про мій вік. Варто мені збрехати чи відповісти чесно?");
        Console.Write("\nСказати вік >>> ");
        
        string input = Console.ReadLine();
        
        Console.WriteLine("\nСтарець послухав мене, нахиливши голову, ніби з невеликим скепсисом.\nАж потім він сказав: ");
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
        if (age <= 0 || age >= 120)
        {
            return "Здається ти мені збрехав. Не може бути такого віку. Ходи геть, брехун!";
        }
        else if (age <= 12)
        {
            return "Надто малий ти ще для таких пригод, друже. Йди звідси!";
        }
        else if (age >= 13 && age < 17)
        {
            return "Підліток це добре, але все ще недостатньо. Ходи геть!";
        }
        else if (age >= 18 && age < 59)
        {
            return "Що ж, ти у гарному віці. Добре, проходь";
        }
        else
        {
            return "Для таких пригод ти вже надто старий. Не пройдеш ти сюди!";
        }
    }
}