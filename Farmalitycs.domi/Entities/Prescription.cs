using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmalitycs.Domain.Entities
{
    public class Prescription
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int MedicineId { get; set; }
        public DateTime IssueDate { get; set; }
        public string Instructions { get; set; }
    }
}

