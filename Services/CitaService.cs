using ClinicaCitas.Models;

namespace ClinicaCitas.Services
{
    public class CitaService : ICitaService
    {
        // Lista estática para simular la persistencia de datos solicitada en la rúbrica
        private static readonly List<Cita> _citas = new List<Cita>
        {
            new Cita { Id = 1, PacienteId = 1, MedicoId = 1, FechaHora = DateTime.Now.AddDays(1), Motivo = "Chequeo general preventivo", Estado = "Programada" },
            new Cita { Id = 2, PacienteId = 2, MedicoId = 2, FechaHora = DateTime.Now.AddDays(2), Motivo = "Lectura de análisis de sangre", Estado = "Programada" },
            new Cita { Id = 3, PacienteId = 3, MedicoId = 1, FechaHora = DateTime.Now.AddDays(4), Motivo = "Dolor muscular crónico", Estado = "Programada" }
        };

        public IEnumerable<Cita> ObtenerTodas() => _citas;

        public Cita? ObtenerPorId(int id) => _citas.FirstOrDefault(c => c.Id == id);

        public Cita Registrar(Cita cita)
        {
            // Autoincrementar el ID simulando una base de datos
            cita.Id = _citas.Any() ? _citas.Max(c => c.Id) + 1 : 1;

            // Forzar el estado inicial
            cita.Estado = "Programada";
            _citas.Add(cita);

            return cita;
        }

        public bool Actualizar(int id, Cita citaActualizada)
        {
            var citaExistente = ObtenerPorId(id);
            if (citaExistente == null) return false;

            citaExistente.PacienteId = citaActualizada.PacienteId;
            citaExistente.MedicoId = citaActualizada.MedicoId;
            citaExistente.FechaHora = citaActualizada.FechaHora;
            citaExistente.Motivo = citaActualizada.Motivo;
            citaExistente.Estado = citaActualizada.Estado;

            return true;
        }

        public bool Eliminar(int id)
        {
            var cita = ObtenerPorId(id);
            if (cita == null) return false;

            return _citas.Remove(cita);
        }
    }
}