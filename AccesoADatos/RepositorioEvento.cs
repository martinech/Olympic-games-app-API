using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using LogicaDeNegocio.Exceptions;

namespace AccesoADatos
{
    public class RepositorioEvento : IRepositorioEvento
    {
        private DbContext _contexto;

        public RepositorioEvento(DbContext contexto)
        {
            _contexto = contexto;
        }

        public int Crear(Evento evento)
        {
            if (_contexto.Set<Evento>().Any(e => e.Nombre == evento.Nombre))
                throw new DatoInvalidoException();
            else
            {
                _contexto.Set<Evento>().Add(evento);
                _contexto.SaveChanges();
                return evento.Id;
            }
        }

        public Evento GetEventoPorId(int id)
        {
            return _contexto.Set<Evento>().Include(e => e.EventoAtletas).ThenInclude(ea => ea.Atleta).FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Evento> GetEventos()
        {
            return _contexto.Set<Evento>().Include(eventos => eventos.EventoAtletas).ToList();
        }

        public void Modificar(int id, Evento evento)
        {
            Evento EventoAModificar = _contexto.Set<Evento>().FirstOrDefault(t => t.Id == id);
            EventoAModificar.Copiar(evento);
            _contexto.Entry(EventoAModificar).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public void Eliminar(int id)
        {
            Evento eventoAEliminar = _contexto.Set<Evento>().FirstOrDefault(t => t.Id == id);
            _contexto.Set<Evento>().Remove(eventoAEliminar);
            _contexto.SaveChanges();
        }

        public IEnumerable<Evento> GetEventosPorFecha(DateTime fechaevento)
        {
            return _contexto.Set<Evento>().Where(evento => evento.FechaFin ==  fechaevento).ToList();//Agregue ToList();
        }

        public void ModificarEventoAtleta(int idEvento, int idAtleta, EventoAtleta eventoAtleta)
        {
            EventoAtleta eventoAtletaAModificar = _contexto.Set<EventoAtleta>()
                .FirstOrDefault(e => e.idEvento == idEvento && e.idAtleta == idAtleta);
            eventoAtletaAModificar.Copiar(eventoAtleta);
            _contexto.Entry(eventoAtletaAModificar).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public IEnumerable<Evento> GetEventosPorDisciplina(string disciplina)
        {
            return _contexto.Set<Evento>().Where(e => e.Disciplina  == disciplina).ToList();
        }

        public IEnumerable<Evento> GetEventosPorNombre(string nombre)
        {
            return _contexto.Set<Evento>()
                        .Where(e => e.Nombre.Contains(nombre)).ToList();
        }

        public IEnumerable<Evento> GetEventosPorFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            return _contexto.Set<Evento>().Where(e => e.FechaInicio >= fechaInicio && e.FechaInicio <= fechaFin).ToList();
        }

        public IEnumerable<Evento> GetEventosPorPuntajes(int puntaje1, int puntaje2)
        {
            return _contexto.Set<Evento>().Where(e => e.EventoAtletas.Any(ea => ea.Puntaje >= puntaje1 && ea.Puntaje <= puntaje2))
               .ToList();
        }
    }
}
