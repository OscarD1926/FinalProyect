namespace Farmalitycs.Infrastructure.Models
{
    public class PrescriptionModel
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateTime IssuedDate { get; set; }
        public string DoctorName { get; set; }

        public List<PrescriptionItemModel> Items { get; set; }
    }

    public class PrescriptionItemModel
    {
        public int MedicineId { get; set; }
        public int Quantity { get; set; }
    }
}

