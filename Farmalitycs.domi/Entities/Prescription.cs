using Farmalitycs.Domain.Entities;

public class Prescription
{
    public int Id { get; set; }

    public int PatientId { get; set; }
    public Patient Patient { get; set; }
    public int? MedicineId { get; set; }
    public Medicine? Medicine { get; set; }
    public List<Medicine> Medicines { get; set; } = new List<Medicine>();

    public DateTime IssueDate { get; set; }
    public string Instructions { get; set; }
}
