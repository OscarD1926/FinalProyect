using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Farmalitycs.Application.Dtos
{
    public class PrescriptionDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El ID del paciente es obligatorio.")]
        public int PatientId { get; set; }

       
        public int? MedicineId { get; set; }

        [Required(ErrorMessage = "La fecha de emisión es obligatoria.")]
        public DateTime IssueDate { get; set; }

        [Required(ErrorMessage = "Las instrucciones son obligatorias.")]
        [StringLength(500, ErrorMessage = "Las instrucciones no pueden exceder 500 caracteres.")]
        public string Instructions { get; set; }

        
        public List<int> MedicinesIds { get; set; } = new();
    }
}
