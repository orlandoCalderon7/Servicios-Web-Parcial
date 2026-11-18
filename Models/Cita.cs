using System.ComponentModel.DataAnnotations;

namespace ClinicaCitas.Models
{
    public class Cita
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El ID del paciente es obligatorio.")]
        public int PacienteId { get; set; }

        [Required(ErrorMessage = "El ID del médico es obligatorio.")]
        public int MedicoId { get; set; }

        [Required(ErrorMessage = "La fecha y hora de la cita es obligatoria.")]
        public DateTime FechaHora { get; set; }

        [StringLength(200, ErrorMessage = "El motivo no puede exceder los 200 caracteres.")]
        public string? Motivo { get; set; }

        // Estado por defecto al crear una cita
        public string Estado { get; set; } = "Programada";
    }
}