using LogicaDeNegocio.Entidades;

namespace LogicaDeNegocio.InterfacesRepositorios
{
    public interface IRepositorioEvento
    {
        void Crear(Evento evento);
        IEnumerable<Evento> GetEventos();
        Evento GetEventoPorId(int id);
        void Modificar(int id, Evento evento);
        void Eliminar(int id);
    }
}
