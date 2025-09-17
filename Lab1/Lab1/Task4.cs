using System;

namespace lab1;

public class Task4
{
    public static void JustDoIt()
    {
        Console.Clear();
        
        Console.WriteLine("Як тільки я зробив крок цим шляхом, щось врізалось у мій загривок, і я знепритомнів." 
                          + "\nПрокинувшись, я опинився посеред трикутної кімнати, що була осіяна світлом червоно-білих кольорів. А стояв я на підлозі також трикутної форми.\n" 
                          + "\nЯкась трикутна істота, схожа на Цефалон з Warframe, підлитіла до мене, та запитала 3 сторони трикутника.");
        
        Console.Write("Назвати сторону a >>> ");
        double a = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("Назвати сторону b >>> ");
        double b = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("Назвати сторону c >>> ");
        double c = Convert.ToDouble(Console.ReadLine());
        
        if (a <= 0 || b <= 0 || c <= 0)
        {
            Console.WriteLine("\nСхоже, що я помилився, і всі сторони мали бути додатніми."
                              + "\nУсе, і кімната, і ця істота, почали світитися лиш яскраво червоним світлом." 
                              + "\nПідлога почала повільно відчинятись, та зрештою я почав падати..."
                              + "\n\nBad Ending");
            Console.ReadKey();
            return;
        }
        
        if (!IsValidTriangle(a, b, c))
        {
            Console.WriteLine("\nСхоже, що я помилився, і ці сторони не можуть утворювати трикутник."
                              + "\nУсе, і кімната, і ця істота, почали світитися лиш яскраво червоним світлом." 
                              + "\nПідлога почала повільно відчинятись, та зрештою я почав падати..."
                              + "\n\nBad Ending");
            Console.ReadKey();
            return;
        }
        
        Console.WriteLine("\nЯ відповів правильно, і мені доповіли результати:");
        Console.WriteLine($"Периметр: {GetPerimeter(a, b, c):F2}");
        Console.WriteLine($"Площа: {GetArea(a, b, c):F2}");
        Console.WriteLine($"Тип трикутника: {GetTriangleType(a, b, c)}");
        
        Console.WriteLine("\nЦя істота пішла у напрямку якоїсь двері, і сказала слідувати за нею...\n\nGood Ending");
        
        Console.ReadKey();
    }
    
    public static bool IsValidTriangle(double a, double b, double c)
    {
        return a + b > c && a + c > b && b + c > a;
    }
    
    public static double GetPerimeter(double a, double b, double c)
    {
        return a + b + c;
    }
    
    public static double GetArea(double a, double b, double c)
    {
        double p = GetPerimeter(a, b, c) / 2; // півпериметр
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }
    
    public static string GetTriangleType(double a, double b, double c)
    {
        if (Math.Abs(a - b) < 0.0001 && Math.Abs(b - c) < 0.0001)
        {
            return "рівносторонній";
        }
        
        if (Math.Abs(a - b) < 0.0001 || Math.Abs(a - c) < 0.0001 || Math.Abs(b - c) < 0.0001)
        {
            return "рівнобедрений";
        }
        
        double a2 = a * a;
        double b2 = b * b;
        double c2 = c * c;
        
        if (Math.Abs(a2 + b2 - c2) < 0.0001 || 
            Math.Abs(a2 + c2 - b2) < 0.0001 || 
            Math.Abs(b2 + c2 - a2) < 0.0001)
        {
            return "прямокутний";
        }
        
        return "довільний";
    }
}