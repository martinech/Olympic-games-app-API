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

        public void Crear(Evento evento)
        {
            if (_contexto.Set<Evento>().Any(e => e.Nombre == evento.Nombre))
                throw new DatoInvalidoException();
            else
            {
                _contexto.Set<Evento>().Add(evento);
                _contexto.SaveChanges();
            }
        }

        public Evento GetEventoPorId(int id)
        {
            return _contexto.Set<Evento>().Include(e => e.EventoAtletas).FirstOrDefault(e => e.Id == id);
            //return _contexto.Set<Evento>().Include(e => e.Atletas).FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Evento> GetEventos()
        {
            return _contexto.Set<Evento>().ToList();
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
    }
}
