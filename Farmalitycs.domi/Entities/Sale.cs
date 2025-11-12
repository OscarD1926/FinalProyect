using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmalitycs.Domain.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public int PrescriptionId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}

