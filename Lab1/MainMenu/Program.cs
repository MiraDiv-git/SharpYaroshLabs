// Дико вибачаюсь за джава-стиль
namespace MainMenu;

public class Program
{
    public static void Main()
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
                    Task1.Program.Main();
                    break;
                
                case "2":
                    Task2.Program.Main();
                    break;
                case "3":
                    Task3.Program.Main();
                    break;
                case "4":
                    Task4.Program.Main();
                    break;
                case "5":
                    Task5.Program.Main();
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