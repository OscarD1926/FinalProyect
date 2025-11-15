using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Farmalitycs.Application.Dtos
{
    public class MedicineDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El tipo es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El tipo no puede tener más de 50 caracteres.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "La fecha de expiración es obligatoria.")]
        public DateTime ExpirationDate { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "La cantidad en stock debe ser 0 o mayor.")]
        public int StockQuantity { get; set; }

        public List<int> PrescriptionsIds { get; set; } = new List<int>();
    }
}
