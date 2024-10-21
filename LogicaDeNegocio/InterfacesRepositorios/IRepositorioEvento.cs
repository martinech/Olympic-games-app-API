using LogicaDeNegocio.Entidades;

namespace LogicaDeNegocio.InterfacesRepositorios
{
    public interface IRepositorioEvento
    {
        int Crear(Evento evento);
        IEnumerable<Evento> GetEventos();
        Evento GetEventoPorId(int id);
        void Modificar(int id, Evento evento);
        void Eliminar(int id);
        IEnumerable<Evento> GetEventosPorFecha(DateTime fechaFin);
    }
}
