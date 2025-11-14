namespace Farmalitycs.Infrastructure.Models
{
    public class SaleModel
    {
        public int Id { get; set; }
        public int PrescriptionId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal Total { get; set; }
    }
}
