using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Farmalitycs.Application.Dtos
{
    public class PatientDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre completo es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El nombre completo no puede tener más de 100 caracteres.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "La identificación es obligatoria.")]
        [MaxLength(20, ErrorMessage = "La identificación no puede tener más de 20 caracteres.")]
        public string Identification { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [Phone(ErrorMessage = "Debe ser un número de teléfono válido.")]
        public string Phone { get; set; }

        public List<int> PrescriptionsIds { get; set; } = new List<int>();
    }
}
