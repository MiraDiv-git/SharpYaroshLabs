using System.Text;

namespace HospitalManagementSystem;

public class HospitalDemo
{
    public void Run(string[] args)
    {
        string login = "sasha_jaroshewsky";
        string passwd = "12345678";
            
        Console.Clear();
            
        Console.Write("Ласкаво просимо до системи управління лікарні ім. Кощія Безсмертного!\n\n" +
                      "Цей застосунок призначений тільки для адміністрації.\nАвторизація: Логін -> ");
        string loginInput = Console.ReadLine();

        Console.Write("Пароль -> ");
        string passwdInput = ReadPasswd();

        if (loginInput != login || passwdInput != passwd)
        {
            Console.WriteLine("Помилка авторизації!\nНевірний логін або пароль\n\n" +
                              "Натисніть будь-яку клавішу, щоб продовжити...");
            Console.ReadKey();
            Environment.Exit(0);
        }
        
        Hospital hospital = new Hospital();
        
        // Додавання лікарів
        hospital.AddDoctor(new Doctor(89752846, 
            "Биков Андрій Євгенійович", 
            "Терапевт"));
        hospital.AddDoctor(new Doctor(52347812, 
            "Хаус Грегорі Джонович",
            "Діагност"));
        hospital.AddDoctor(new Doctor(13372284,
        "Мерфі Шон Ітанович",
        "Хірург"));
        
        // Реєстрація пацієнтів
        hospital.RegisterPatient(new Patient(0000001, 
            "Солдатов Андрій Дмитрович", 
            20));
        hospital.RegisterPatient(new Patient(0000002, 
            "Киян Маргарита Сергіївна", 
            19));
        hospital.RegisterPatient(new Patient(0000003,
            "Колчанов Владислав Володимирович",
            18));
        hospital.RegisterPatient(new Patient(0000004,
            "Стетий Максим Гігачадович",
            19)); // Я реально не знаю його по батькові
        
        // Створення палат
        hospital.CreateRoom(new HospitalRoom(1, 2));
        hospital.CreateRoom(new  HospitalRoom(2, 1));
        
        // Госпіталізація
        hospital.HospitalizePatient(0000001, 1);
        hospital.HospitalizePatient(0000002, 1);
        hospital.HospitalizePatient(0000003, 2);
        hospital.HospitalizePatient(0000004, 2);
        
        // Медичні записи
        hospital.AddMedicalRecord(new MedicalRecord(hospital.Patients[0], 
            hospital.Doctors[1],
            DateTime.Today,
            WritePatientDesc(hospital.Patients[0].Id)));
        hospital.AddMedicalRecord(new MedicalRecord(hospital.Patients[1], 
            hospital.Doctors[0],
            DateTime.Today,
            WritePatientDesc(hospital.Patients[1].Id)));
        hospital.AddMedicalRecord(new MedicalRecord(hospital.Patients[2], 
            hospital.Doctors[1],
            DateTime.Today,
            WritePatientDesc(hospital.Patients[2].Id)));
        hospital.AddMedicalRecord(new MedicalRecord(hospital.Patients[3], 
            hospital.Doctors[2],
            DateTime.Today,
            WritePatientDesc(hospital.Patients[3].Id)));
        
        // Історія пацієнта
        Console.WriteLine("\n--- ІСТОРІЇ ВСІХ ПАЦІЄНТІВ ---");
        foreach (var patient in hospital.Patients)
        {
            Console.WriteLine($"\nІсторія пацієнта: {patient.Name} (ID: {patient.Id})");
            var history = hospital.GetPatientHistory(patient.Id);
            foreach (var record in history)
            {
                Console.WriteLine($"  Дата: {record.Date.ToShortDateString()}");
                Console.WriteLine($"  Лікар: {record.Doctor.Name}");
                Console.WriteLine($"  Опис: {record.Description}");
            }
        }

        // Статистика
        Console.WriteLine(hospital.GetStatistics());
    }

    private string WritePatientDesc(int patientId)
    {
        string d1 = "Потрапив до лікарні у зв'язку з алкогольним отруєнням від Єгермейтеру.";
        string d2 = "Жаліється на постійний нежить.";
        string d3 = "Втомився від веб-розробки";
        string d4 = "Прийшов похвастатись тим що він здоровий як бик";

        string result;
        switch (patientId)
        {
            case 1:
                return d1;
            case 2:
                return d2;
            case 3:
                return d3;
            case 4:
                return d4;
            default:
                return "Опис відсутній";
        }
    }
    
    private string ReadPasswd(char maskChar = '*')
    {
        var passwd = new StringBuilder();
        ConsoleKeyInfo key;
    
        while ((key = Console.ReadKey(true)).Key != ConsoleKey.Enter)
        {
            if (key.Key == ConsoleKey.Backspace)
            {
                if (passwd.Length > 0)
                {
                    passwd.Remove(passwd.Length - 1, 1);
                    Console.Write("\b \b");
                }
            }
            else if (!char.IsControl(key.KeyChar))
            {
                passwd.Append(key.KeyChar);
                Console.Write(maskChar);
            }
        }
    
        
        Console.ReadKey();
        Console.WriteLine();
        return passwd.ToString();
    }
}