using LogicaDeAplicacion.InterfacesCU.IEventoCU;
using LogicaDeNegocio.InterfacesRepositorios;
using Dto;

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
            return _repositorioEvento.GetEventos().Select(evento => new EventoDto(evento));
        }
    }
}
