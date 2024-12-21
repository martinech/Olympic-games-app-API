using Dto;
using LogicaDeAplicacion.InterfacesCU.IEventoCU;
using LogicaDeNegocio.InterfacesRepositorios;

namespace LogicaDeAplicacion.ImplementacionCU.EventoCU
{
    public class GetEventosPorFechas : IGetEventosPorFechas
    {
        private readonly IRepositorioEvento _repositorioEvento;

        public GetEventosPorFechas(IRepositorioEvento repositorioEvento)
        {
            _repositorioEvento = repositorioEvento;
        }
        public List<EventoDto> Ejecutar(DateTime fechaInicio, DateTime fechaFin)
        {
            List<EventoDto> eventosDto = new List<EventoDto>();

            foreach (var evento in _repositorioEvento.GetEventosPorFechas(fechaInicio, fechaFin))
                eventosDto.Add(new EventoDto(evento));

            return eventosDto;
        }
    }
}
