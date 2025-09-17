using System;

namespace lab1
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                
                Console.WriteLine("Неймовірна пригода Лабораторного Гаю"
                    + "\n\tОберіть свій шлях:" 
                    + "\n\t(1) - Двері до щастя (завдання 1)" 
                    + "\n\t(2) - Масивна конструкція (завдання 2)"
                    + "\n\t(3) - Вічне питання (завдання 3)"
                    + "\n\t(4) - Трикутник смерті (завдання 4)"
                    + "\n\t(5) - Загадговий університет (Завдання 5)"
                    + "\n\t(0) - Шлях прокляття (вихід з програми)");
                Console.Write("Зробіть свій вибір >>> ");
                
                string input = Console.ReadLine();
                
                switch (input)
                {
                    case "1":
                        Z1.JustDoIt();
                        break;
                    
                    case "2":
                        Z2.JustDoIt();
                        break;
                    case "3":
                        Z3.JustDoIt();
                        break;
                    case "4":
                        Z4.JustDoIt();
                        break;
                    case "5":
                        Z5.JustDoIt();
                        break;
                        
                    default:
                        Console.Clear();
                        Console.WriteLine("Ви на порозі до шляху прокляття. Майте на увазі, назад дороги не буде.");
                        Console.Write("Продовжити?\n (1 - так, 2 - ні) >>> ");
                        
                        string confirm = Console.ReadLine();
                        
                        if (confirm == "1")
                        {
                            Environment.Exit(0);
                        }
                        
                        break;
                }
            }
        }
    }
}