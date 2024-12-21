using Dto;
using LogicaDeAplicacion.InterfacesCU.IEventoCU;
using LogicaDeNegocio.InterfacesRepositorios;

namespace LogicaDeAplicacion.ImplementacionCU.EventoCU
{
    public class GetEventosPorPuntajes : IGetEventosPorPuntajes
    {
        private readonly IRepositorioEvento _repositorioEvento;

        public GetEventosPorPuntajes(IRepositorioEvento repositorioEvento)
        {
            _repositorioEvento = repositorioEvento;
        }
        public List<EventoDto> Ejecutar(int puntaje1, int puntaje2)
        {
            List<EventoDto> eventosDto = new List<EventoDto>();

            foreach (var evento in _repositorioEvento.GetEventosPorPuntajes(puntaje1, puntaje2))
                eventosDto.Add(new EventoDto(evento));

            return eventosDto;
        }
    }
}
