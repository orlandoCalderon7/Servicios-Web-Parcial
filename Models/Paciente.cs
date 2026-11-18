using System.ComponentModel.DataAnnotations;

namespace ClinicaCitas.Models
{
    public class Paciente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del paciente es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El DNI es obligatorio.")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "El DNI debe tener 8 dígitos.")]
        public string Dni { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "El formato del correo no es válido.")]
        public string? Email { get; set; }
    }
}