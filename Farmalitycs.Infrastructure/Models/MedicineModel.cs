namespace Farmalitycs.Infrastructure.Models
{
    public class MedicineModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BatchNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Quantity { get; set; }
    }
}

