using System.Collections.Generic;

namespace Farmalitycs.Domain.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Identification { get; set; }
        public string Phone { get; set; }
        public List<Prescription> Prescriptions { get; set; } = new();
    }
}


