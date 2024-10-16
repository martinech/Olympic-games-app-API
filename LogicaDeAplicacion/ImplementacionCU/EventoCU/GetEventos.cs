using Dto;
using LogicaDeNegocio.InterfacesRepositorios;
using LogicaDeNegocio.Entidades;
using LogicaDeAplicacion.InterfacesCU.IEventoCU;

namespace LogicaDeAplicacion.ImplementacionCU.EventoCU
{
    public class GetEventos : IGetEventos
    {
        private readonly IRepositorioEvento _repositorioEvento;
        public GetEventos(IRepositorioEvento repositorio)
        {
            _repositorioEvento = repositorio;
        }
        public IEnumerable<EventoDto> Ejecutar()
        {
            List<EventoDto> eventosDto = new List<EventoDto>();
            IEnumerable<Evento> eventos = _repositorioEvento.GetEventos();

            foreach (Evento u in eventos)
                eventosDto.Add(new EventoDto(u));

            return eventosDto;
        }
    }
}
