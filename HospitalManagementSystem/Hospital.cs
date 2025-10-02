namespace HospitalManagementSystem;

public class Hospital
{
    public List<Doctor> Doctors;
    public List<Patient> Patients;
    public List<HospitalRoom> Rooms;
    public List<MedicalRecord> Records;
    
    public int totalPatientsInRooms;

    public Hospital()
    {
        Doctors = new List<Doctor>();
        Patients = new List<Patient>();
        Rooms = new List<HospitalRoom>();
        Records = new List<MedicalRecord>();
        totalPatientsInRooms = 0;
    }
    
    public void AddDoctor(Doctor doctor)
    {
        Doctors.Add(doctor);
        Console.WriteLine($"Лікар {doctor.Name} ({doctor.Specialization}) доданий до системи");
    }

    public void RegisterPatient(Patient patient)
    {
        Patients.Add(patient);
        Console.WriteLine($"Пацієнт {patient.Name}, {patient.Age} років, зареєстрований");
    }

    public void CreateRoom(HospitalRoom room)
    {
        Rooms.Add(room);
        Console.WriteLine($"Палата №{room.RoomNumber} створена (місткість: {room.Capacity})");
    }

    public void HospitalizePatient(int patientId, int roomNumber)
    {
        Patient patient = Patients.Find(p => p.Id == patientId);
        if (patient == null)
        {
            Console.WriteLine($"Пацієнт з ID {patientId} не знайдений!");
            return;
        }

        HospitalRoom room = Rooms.Find(r => r.RoomNumber == roomNumber);
        if (room == null)
        {
            Console.WriteLine($"Палата №{roomNumber} не знайдена!");
            return;
        }

        try
        {
            room.AddPatient(patient);
            totalPatientsInRooms++;
            Console.WriteLine($"Пацієнт {patient.Name} поміщений у палату №{roomNumber}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }

    public void AddMedicalRecord(MedicalRecord record)
    {
        Patient patient = Patients.Find(p => p.Id == record.Patient.Id);
        if (patient == null)
        {
            Console.WriteLine($"Пацієнт з ID {record.Patient.Id} не знайдений!");
            return;
        }
        
        Doctor doctor = Doctors.Find(d => d.Id == record.Doctor.Id);
        if (doctor == null)
        {
            Console.WriteLine($"Лікар з ID {record.Doctor.Id} не знайдений!");
            return;
        }

        Records.Add(record);
        Console.WriteLine($"Медичний запис створено: {record.Patient.Name} -> {record.Doctor.Name}");
    }

    public List<MedicalRecord> GetPatientHistory(int patientId)
    {
        List<MedicalRecord> patientRecords = Records.FindAll(record => record.Patient.Id == patientId);
        
        if (patientRecords.Count == 0)
        {
            Console.WriteLine($"Для пацієнта з ID {patientId} медичних записів не знайдено");
        }
        
        return patientRecords;
    }

    public string GetStatistics()
    {
        totalPatientsInRooms = Rooms.Sum(room => room.CurrentPatientCount);

        return $"\n=== СТАТИСТИКА ЛІКАРНІ ===\n" +
               $"Кількість лікарів: {Doctors.Count}\n" +
               $"Кількість зареєстрованих пацієнтів: {Patients.Count}\n" +
               $"Кількість палат: {Rooms.Count}\n" +
               $"Кількість пацієнтів у палатах: {totalPatientsInRooms}\n" +
               $"Кількість медичних записів: {Records.Count}\n";
    }
}