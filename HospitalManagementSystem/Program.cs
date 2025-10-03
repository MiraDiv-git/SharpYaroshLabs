namespace HospitalManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            HospitalDemo demo = new HospitalDemo();
            demo.Run(args);

            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
            // Навіть мені було душновато...
            // Сподіваюсь решта зможе це зробити без чатжопеті
        }
    }
}