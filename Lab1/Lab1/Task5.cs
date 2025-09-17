using System;

namespace lab1;

public class Task5
{
    public static void JustDoIt()
    {
        Console.Clear();
        
        Console.WriteLine("Задзвенів дзвоник. Я прокинувся, намагаючись обробити свій робочий сон." 
                          + "\nПодивившись на час - вже було 18:00, пари закінчено, мені вже давно треба додому.\n"
                          + "\nШкода, що навіть удома приходиться працювати, атже настав час виставляти оцінки цим клятим студентам..."
                          + "\nЛіниво відкриваючи Classroom, я почав оцінювати їх криві роботи, попутно переписуючи оцінки в електронний журнал."
                          +"\n\nЗ рештою, за 3 години все було готово. Я завантажив результати на сервер, та побачив бали моїх учнів:\n");
        
        int[][] groups = new int[][]
        {
            new int[] { 85, 90, 78, 92, 88, 76, 95, 82, 79, 91, 84, 87, 93, 80, 86 }, // група 1
            new int[] { 65, 72, 68, 75, 70, 62, 78, 71, 67, 74, 69, 73, 66, 77, 64, 79, 63, 76, 61 }, // група 2
            new int[] { 92, 95, 88, 96, 90, 94, 89, 93, 91, 97, 87, 98, 86, 99, 85, 100, 84 }, // група 3
            new int[] { 55, 62, 58, 67, 60, 53, 69, 63, 57, 66, 59, 65, 56, 68, 54, 70, 52, 64, 51, 61 }, // група 4
            new int[] { 78, 83, 75, 86, 80, 72, 88, 82, 74, 85, 79, 84, 76, 87, 73, 89, 71, 81, 77, 90, 70 } // група 5
        };
        
        PrintGroupStatistics(groups);
        
        Console.WriteLine("\n\nCanonical Ending");
        Console.ReadKey();
    }
    
    public static void PrintGroupStatistics(int[][] groups)
    {
        for (int i = 0; i < groups.Length; i++)
        {
            double average = GetAverage(groups[i]);
            int min = GetMin(groups[i]);
            int max = GetMax(groups[i]);
            
            Console.WriteLine($"ПД-2{i + 1}: Середній = {average:F0}, Мінімальний = {min}, Максимальний = {max}");
        }
    }
    
    public static double GetAverage(int[] marks)
    {
        if (marks == null || marks.Length == 0)
            return 0;
            
        int sum = 0;
        foreach (int mark in marks)
        {
            sum += mark;
        }
        return (double)sum / marks.Length;
    }
    
    public static int GetMin(int[] marks)
    {
        if (marks == null || marks.Length == 0)
            return 0;
            
        int min = marks[0];
        foreach (int mark in marks)
        {
            if (mark < min)
                min = mark;
        }
        return min;
    }
    
    public static int GetMax(int[] marks)
    {
        if (marks == null || marks.Length == 0)
            return 0;
            
        int max = marks[0];
        foreach (int mark in marks)
        {
            if (mark > max)
                max = mark;
        }
        return max;
    }
}