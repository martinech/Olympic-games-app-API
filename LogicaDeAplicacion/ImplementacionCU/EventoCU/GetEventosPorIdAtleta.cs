using Dto;
using LogicaDeAplicacion.InterfacesCU.IEventoCU;
using LogicaDeNegocio.InterfacesRepositorios;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Exceptions;

namespace LogicaDeAplicacion.ImplementacionCU.EventoCU
{
    public class GetEventosPorIdAtleta : IGetEventosPorIdAtleta
    {
        private readonly IRepositorioEvento _repositorioEvento;

        public GetEventosPorIdAtleta(IRepositorioEvento repositorioEvento)
        {
            _repositorioEvento = repositorioEvento;
        }
        public List<EventoDto> Ejecutar(int idAtleta)
        {
            IEnumerable<Evento> eventos = _repositorioEvento.GetEventos();

            if (!eventos.Any())
                throw new DatoInvalidoException("No hay eventos disponibles");

            List<EventoDto> eventoDtoFiltradosPorIdAtleta = new List<EventoDto>();

            foreach (var evento in eventos)
            {
                foreach (var eventoAtleta in evento.EventoAtletas)
                {
                    if (eventoAtleta.idAtleta == idAtleta)
                        eventoDtoFiltradosPorIdAtleta.Add(new EventoDto(evento));
                }
            }
            return eventoDtoFiltradosPorIdAtleta;
        }
    }
}
