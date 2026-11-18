using System.ComponentModel.DataAnnotations;

namespace ClinicaCitas.Models
{
    public class Medico
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del médico es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La especialidad es obligatoria.")]
        [StringLength(50, ErrorMessage = "La especialidad no puede exceder los 50 caracteres.")]
        public string Especialidad { get; set; } = string.Empty;
    }
}