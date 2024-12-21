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
        IEnumerable<Evento> GetEventosPorFecha(DateTime fecha);
        void ModificarEventoAtleta(int idEvento, int idAtleta, EventoAtleta eventoAtleta);
        IEnumerable<Evento> GetEventosPorDisciplina(string disciplina);
        IEnumerable<Evento> GetEventosPorNombre(string nombre);
        IEnumerable<Evento> GetEventosPorFechas(DateTime fechaInicio, DateTime fechaFin);
        IEnumerable<Evento> GetEventosPorPuntajes(int puntaje1, int puntaje2);





    }
}
