using System;

namespace lab1
{
    public class Program
    {
        public void Z1
        {
            Console.WriteLine("Я опинився перед металевими роздвижними дверима.\nПоряд з ними була панель із кодовим замком...");
            
            Console.Write("\nВвести число >>> ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int x))
            {
                if (x % 2 == 0)
                {
                    Console.WriteLine("Двері відчіняються...\nЗа дверима знаходилось надзвичайно казкове місце. \nПобачивши знак \"Запоріжжя\" я зрозумів, що я знайшов своє щастя!..\n\nGood Ending");
                }
                else
                {
                    Console.WriteLine("Двері так і залишились закритими... \nСхоже, що я ніколи не знайду своє щастя...\n\nBad Ending");
                }
            }
            else
            {
                Console.WriteLine("На превеликий жаль, панель сприймає тільки числа");
                Console.ReadKey();
                Z1();
            }
            Console.ReadKey()
    }
        static void Main(string args)
        {
            while (true)
            {
                Console.WriteLine("Неймовірна пригода Лабораторного Гаю"
                    + "\tОберіть свій шлях:\n(1) - Двері до щастя (завдання 1)\n(2) - Масивна конструкція (завдання 2)\n(0) - Шлях прокляття (вихід з програми)");
                Console.WriteLine("Зробіть свій вибір >>> ");
                string input = Console.ReadLine();
                switch input()
                {
                    case "1":
                        Z1();
                        break;
                        
                    default:
                    Console.WriteLine("Ви на порозі до шляху прокляття. Майте на увазі, назад дороги не буде.");
                    Console.Write("Продовжити?\n (1 - так, 2 - ні) >>>");
                    string confirm = Console.ReadLine();
                    if (confirm == "1")
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
    }
}