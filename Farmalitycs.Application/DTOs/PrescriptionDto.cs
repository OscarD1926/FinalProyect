namespace Farmalitycs.Application.Dtos
{
    public class PrescriptionDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int? MedicineId { get; set; }
        public DateTime IssueDate { get; set; }
        public string Instructions { get; set; }
        public List<int> MedicineIds { get; set; } = new List<int>();
    }
}