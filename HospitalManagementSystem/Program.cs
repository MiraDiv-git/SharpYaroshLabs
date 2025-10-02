namespace HospitalManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            var hospital = new Hospital();
            
            hospital.AddDoctor(new Doctor(1, "Биков Андрій Євгенович", "Терапевт"));
            hospital.AddDoctor(new Doctor(2, "Купітман Іван Нататович", "Венеролог"));
            hospital.AddDoctor(new Doctor(3, "Лобанов Семен Сергійович", "Хірург"));
            hospital.AddDoctor(new Doctor(4, "Романенко Гліб Вікторович", "Лор"));
            hospital.AddDoctor(new Doctor(5, "Філ Річардс", "Невролог"));
            
            hospital.RegisterPatient(new Patient(1, "Солдатов Андрій Дмитрович", 20));   
            hospital.RegisterPatient(new Patient(2, "Киян Маргарита Сергіївна", 19));
            hospital.RegisterPatient(new Patient(3, "Ніжинський Нікіта Олегович", 18));
        }
    }
}