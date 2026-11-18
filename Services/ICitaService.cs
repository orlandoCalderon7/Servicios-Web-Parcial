using ClinicaCitas.Models;

namespace ClinicaCitas.Services
{
    public interface ICitaService
    {
        IEnumerable<Cita> ObtenerTodas();
        Cita? ObtenerPorId(int id);
        Cita Registrar(Cita cita);
        bool Actualizar(int id, Cita cita);
        bool Eliminar(int id);
    }
}