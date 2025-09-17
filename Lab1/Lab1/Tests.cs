namespace lab1;

public class Tests
{
    public static void Run()
    {
        Tests tests = new Tests();

        tests.Task1_Tests();
        Console.WriteLine("");
        
        tests.Task2_Tests();
        Console.WriteLine("");
        
        tests.Task3_Tests();
        Console.WriteLine("");
        
        tests.Task4_Tests();
        Console.WriteLine("");
        
        tests.Task5_Tests();
    }

    private void Task1_Tests()
    {
        Console.WriteLine("\n\n  ////////////////\n //// Task 1 ////\n////////////////\n\n");
        
        Console.WriteLine("Testing Task1.IsEven()");
        
        int a = 12;
        int b = 11;
        
        Task1.IsEven(a);
        Task1.IsEven(b);
        
        Console.WriteLine($"A value: {a}, {Task1.IsEven(12)}\nB value: {b}, {Task1.IsEven(b)}");
    }

    private void Task2_Tests()
    {
        Console.WriteLine("\n\n  ////////////////\n //// Task 2 ////\n////////////////\n\n");
        
        Console.WriteLine("Testing Task2.GenerateRandomArray()");
        
        int size = 10;
        int min = 1;
        int max = 100;
        
        int[] numbers = Task2.GenerateRandomArray(size, min, max);
        
        Console.Write("Generated array: ");
        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine($"\nTesting Task2.GetSum(): {Task2.GetSum(numbers)}");
        Console.WriteLine($"Testing Task2.GetAverage(): {Task2.GetAverage(numbers):F2}");
        Console.WriteLine($"Testing Task2.GetMin(): {Task2.GetMin(numbers)}");
        Console.WriteLine($"Testing Task2.GetMax(): {Task2.GetMax(numbers)}");
    }

    private void Task3_Tests()
    {
        Console.WriteLine("\n\n  ////////////////\n //// Task 3 ////\n////////////////\n\n");
        
        int age1 = 10;
        int age2 = 13;
        int age3 = 19;
        int age4 = 43;
        int age5 = 75;
        int age6 = -20;
        int age7 = 82374;
        
        Console.WriteLine("Testing Task3.ClassifyAge()");
        Console.WriteLine("---------------------------------------------------------------------------------------------\n" 
                          + "Age\t\tAnswer\n"
                          + $"\n{age1}\t\t{Task3.ClassifyAge(age1)}"
                          + $"\n{age2}\t\t{Task3.ClassifyAge(age2)}"
                          + $"\n{age3}\t\t{Task3.ClassifyAge(age3)}"
                          + $"\n{age4}\t\t{Task3.ClassifyAge(age4)}"
                          + $"\n{age5}\t\t{Task3.ClassifyAge(age5)}"
                          + $"\n{age6}\t\t{Task3.ClassifyAge(age6)}"
                          + $"\n{age7}\t\t{Task3.ClassifyAge(age7)}"
                          + "\n---------------------------------------------------------------------------------------------\n");
    }

    private void Task4_Tests()
    {
        Console.WriteLine("\n\n  ////////////////\n //// Task 4 ////\n////////////////\n\n");
        
        // Isosceles Triangle
        double a1 = 12;
        double b1 = 3;
        
        // Equilateral Triangle
        double a2 = 8;
        
        // Rectangular Triangle
        double a3 = 3;
        double b3 = 4;
        double c3 = 5;
        
        //Impossible Triangle
        double a4 = -12;
        double b4 = 0;
        double c4 = 86745;
        Console.WriteLine($"First triangle: A: {a1}, B: {b1}, C: {a1}" +
                          $"\nTesting Task4.IsValidTriangle(): {Task4.IsValidTriangle(a1, b1, a1)}" +
                          $"\nTesting Task4.GetPerimeter(): {Task4.GetPerimeter(a1, b1, a1)}" +
                          $"\nTesting Task4.GetArea(): {Task4.GetArea(a1, b1, a1)}" +
                          $"\nTesting Task4.GetTriangleType(): {Task4.GetTriangleType(a1, b1, a1)}\n");
        Console.WriteLine($"Second triangle: A: {a2}, B: {a2}, C: {a2}" +
                          $"\nTesting Task4.IsValidTriangle(): {Task4.IsValidTriangle(a2, a2, a2)}" +
                          $"\nTesting Task4.GetPerimeter(): {Task4.GetPerimeter(a2, a2, a2)}" +
                          $"\nTesting Task4.GetArea(): {Task4.GetArea(a2, a2, a2)}" +
                          $"\nTesting Task4.GetTriangleType(): {Task4.GetTriangleType(a2, a2, a2)}\n");
        Console.WriteLine($"Third triangle: A: {a3}, B: {b3}, C: {c3}" +
                          $"\nTesting Task4.IsValidTriangle(): {Task4.IsValidTriangle(a3, b3, c3)}" +
                          $"\nTesting Task4.GetPerimeter(): {Task4.GetPerimeter(a3, b3, c3)}" +
                          $"\nTesting Task4.GetArea(): {Task4.GetArea(a3, b3, c3)}" +
                          $"\nTesting Task4.GetTriangleType(): {Task4.GetTriangleType(a3, b3, c3)}\n");
        Console.WriteLine($"Impossible triangle: A: {a4}, B: {b4}, C: {c4}" +
                          $"\nTesting Task4.IsValidTriangle(): {Task4.IsValidTriangle(a4, b4, c4)}" +
                          $"\nTesting Task4.GetPerimeter(): {Task4.GetPerimeter(a4, b4, c4)}" +
                          $"\nTesting Task4.GetArea(): {Task4.GetArea(a4, b4, c4)}" +
                          $"\nTesting Task4.GetTriangleType(): {Task4.GetTriangleType(a4, b4, c4)}\n");
    }

    private void Task5_Tests()
    {
        Console.WriteLine("\n\n  ////////////////\n //// Task 5 ////\n////////////////\n\n");
        
        int[][] groups = new int[][]
        {
            new int[] { 85, 90, 78, 92, 88, 76, 95, 82, 79, 91, 84, 87, 93, 80, 86 }, // група 1
            new int[] { 65, 72, 68, 75, 70, 62, 78, 71, 67, 74, 69, 73, 66, 77, 64, 79, 63, 76, 61 }, // група 2
            new int[] { 92, 95, 88, 96, 90, 94, 89, 93, 91, 97, 87, 98, 86, 99, 85, 100, 84 }, // група 3
            new int[] { 55, 62, 58, 67, 60, 53, 69, 63, 57, 66, 59, 65, 56, 68, 54, 70, 52, 64, 51, 61 }, // група 4
            new int[] { 78, 83, 75, 86, 80, 72, 88, 82, 74, 85, 79, 84, 76, 87, 73, 89, 71, 81, 77, 90, 70 } // група 5
        };

        Console.WriteLine("Testing Task5.PrintGroupStatistics");
        Task5.PrintGroupStatistics(groups);
    }
}