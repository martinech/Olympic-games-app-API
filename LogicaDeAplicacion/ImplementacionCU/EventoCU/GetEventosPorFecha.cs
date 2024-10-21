using Dto;
using LogicaDeAplicacion.InterfacesCU.IEventoCU;
using LogicaDeNegocio.InterfacesRepositorios;

namespace LogicaDeAplicacion.ImplementacionCU.EventoCU
{
    public class GetEventosPorFecha : IGetEventosPorFecha
    {
        private readonly IRepositorioEvento _repositorioEvento;

        public GetEventosPorFecha(IRepositorioEvento repositorioEvento)
        {
            _repositorioEvento = repositorioEvento;
        }
        public List<EventoDto> Ejecutar(DateTime fechaEvento)
        {
            List<EventoDto> eventosDto = new List<EventoDto>();

            foreach (var evento in _repositorioEvento.GetEventosPorFecha(fechaEvento))
                eventosDto.Add(new EventoDto(evento));

            return eventosDto;
        }
    }
}
