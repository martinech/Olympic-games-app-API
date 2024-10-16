using Dto;
using LogicaDeAplicacion.InterfacesCU.IEventoCU;
using LogicaDeNegocio.Exceptions;
using LogicaDeNegocio.InterfacesRepositorios;
using LogicaDeNegocio.Entidades;

namespace LogicaDeAplicacion.ImplementacionCU.EventoCU
{
    public class GetEventoPorId : IGetEventoPorId
    {
        private readonly IRepositorioEvento _repositorioEvento;

        public GetEventoPorId(IRepositorioEvento repositorio)
        {
            _repositorioEvento = repositorio;
        }
        public EventoDto Ejecutar(int id)
        {
            Evento evento = _repositorioEvento.GetEventoPorId(id);
            if (evento is not null)
            {
                EventoDto eventoDto = new EventoDto(evento);
                return eventoDto;
            }
            else
                throw new EventoInvalidoException("Operacion invalida");
        }
    }
}
