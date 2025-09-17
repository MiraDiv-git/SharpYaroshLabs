// Дико вибачаюсь за джава-стиль
namespace Task2;

public class Program
{
    public static void Main()
    {
        Console.Clear();

        int[] numbers = GenerateRandomArray(10, 1, 100);
        
        Console.WriteLine("Йшовши цією тропою, я натрапив на невідому масивну конструкцію. \nНа ній були цифри:\n");
        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }
        
        Console.WriteLine("\n\nЗрозумівши, що це якась математична комбінація, я почав міркувати, та згодом зробив такі висновки: ");
        
        Console.WriteLine($"Сума: {GetSum(numbers)}");
        Console.WriteLine($"Середнє: {GetAverage(numbers):F2}");
        Console.WriteLine($"Мінімум: {GetMin(numbers)}");
        Console.WriteLine($"Максимум: {GetMax(numbers)}");
        
        Console.WriteLine("\nАле згодом я прийшов думки, що це було марно...\nКожен раз коли я відвертаюсь, цифри знову змінюються...\n\nBad Ending");

        Console.ReadKey();
    }
    
    public static int[] GenerateRandomArray(int size, int min, int max)
    {
        Random random = new Random();
        int[] array = new int[size];
        
        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(min, max + 1);
        }
        
        return array;
    }
    
    public static int GetSum(int[] numbers)
    {
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        return sum;
    }
    
    public static double GetAverage(int[] numbers)
    {
        return (double)GetSum(numbers) / numbers.Length;
    }
    
    public static int GetMin(int[] numbers)
    {
        int min = numbers[0];
        foreach (int number in numbers)
        {
            if (number < min)
            {
                min = number;
            }
        }
        return min;
    }
    
    public static int GetMax(int[] numbers)
    {
        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        return max;
    }
}