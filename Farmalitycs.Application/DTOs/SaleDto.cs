using System;
using System.ComponentModel.DataAnnotations;

namespace Farmalitycs.Application.Dtos
{
    public class SaleDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El ID de la prescripción es obligatorio.")]
        public int PrescriptionId { get; set; }

        [Required(ErrorMessage = "La fecha de la venta es obligatoria.")]
        public DateTime SaleDate { get; set; }

        [Required(ErrorMessage = "El monto total es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El monto total debe ser mayor o igual a 0.")]
        public decimal TotalAmount { get; set; }
    }
}
