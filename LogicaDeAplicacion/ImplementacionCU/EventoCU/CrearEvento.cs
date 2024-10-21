using Dto;
using LogicaDeAplicacion.InterfacesCU.IEventoCU;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Exceptions;
using LogicaDeNegocio.InterfacesRepositorios;

namespace LogicaDeAplicacion.ImplementacionCU.EventoCU
{
    public class CrearEvento : ICrearEvento
    {
        private readonly IRepositorioEvento _repositorioEvento;

        public CrearEvento(IRepositorioEvento repositorio)
        {
            _repositorioEvento = repositorio;
        }
        public int Ejecutar(EventoDto eventoDto)
        {
            IEnumerable<Evento> eventosExistentes = _repositorioEvento.GetEventos();
            if (eventosExistentes.Any(e => e.Nombre.Equals(eventoDto.Nombre)))
            {
                throw new DatoInvalidoException("Ya existe un evento con ese nombre.");
            } else
            {
                Evento eventoNuevo = eventoDto.ToEvento();
                eventoNuevo.Validar();
                int eventoId = _repositorioEvento.Crear(eventoNuevo);
                return eventoId;
            }
        }
    }
}   
