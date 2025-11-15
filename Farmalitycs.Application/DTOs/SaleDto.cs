namespace Farmalitycs.Application.Dtos
{
    public class SaleDto
    {
        public int Id { get; set; }
        public int PrescriptionId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}