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
    }

    public void RegisterPatient(Patient patient)
    {
        Patients.Add(patient);
    }

    public void CreateRoom(HospitalRoom room)
    {
        Rooms.Add(room);
    }

    public void HospitalizePatient(int patientId, int roomNumber)
    {
        Patient patient = Patients.Find(p => p.Id == patientId);
        if (patient == null)
        {
            return;
        }

        HospitalRoom room = Rooms.Find(r => r.RoomNumber == roomNumber);
        if (room == null)
        {
            return;
        }

        try
        {
            room.AddPatient(patient);
            totalPatientsInRooms++;
        }
        catch (InvalidOperationException)
        {
        }
    }

    public void AddMedicalRecord(MedicalRecord record)
    {
        Records.Add(record);
    }

    public List<MedicalRecord> GetPatientHistory(int patientId)
    {
        List<MedicalRecord> patientRecords = Records.FindAll(record => record.Patient.Id == patientId);
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