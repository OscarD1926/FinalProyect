public class Medicine
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int StockQuantity { get; set; }

    public List<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}



