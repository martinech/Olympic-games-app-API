using Dto;
using LogicaDeAplicacion.InterfacesCU.IEventoCU;
using LogicaDeNegocio.Exceptions;
using LogicaDeNegocio.InterfacesRepositorios;
using LogicaDeNegocio.Entidades;

namespace LogicaDeAplicacion.ImplementacionCU.EventoCU
{
    public class GetEventosPorNombre : IGetEventosPorNombre
    {
        private readonly IRepositorioEvento _repositorioEvento;

        public GetEventosPorNombre(IRepositorioEvento repositorio)
        {
            _repositorioEvento = repositorio;
        }
        public List<EventoDto> Ejecutar(string nombre)
        {
            List<EventoDto> eventosDto = new List<EventoDto>();

            foreach (var evento in _repositorioEvento.GetEventosPorNombre(nombre))
                eventosDto.Add(new EventoDto(evento));


            return eventosDto;
        }
    }
}
