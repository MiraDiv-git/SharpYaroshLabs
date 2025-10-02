namespace HospitalManagementSystem;

public class MedicalRecord
{
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }

    public MedicalRecord(Patient patient, Doctor doctor, DateTime date, string description)
    {
        Patient = patient;
        Doctor = doctor;
        Date = date;
        Description = description;
    }

    public static void WriteMedicalRecord(MedicalRecord medicalRecord)
    {
        Console.WriteLine($"Пацієнт: {medicalRecord.Patient}\n" +
                          $"Лікує: {medicalRecord.Doctor}\n" +
                          $"Дата запису: {medicalRecord.Date}\n" +
                          $"Стан пацієнта: {medicalRecord.Description}\n");
    }
}