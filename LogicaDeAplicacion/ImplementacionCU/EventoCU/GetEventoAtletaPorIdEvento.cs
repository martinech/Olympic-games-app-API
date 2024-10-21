using Dto;
using LogicaDeAplicacion.InterfacesCU.IEventoCU;
using LogicaDeNegocio.InterfacesRepositorios;
using LogicaDeNegocio.Entidades;

namespace LogicaDeAplicacion.ImplementacionCU.EventoCU
{
    public class GetEventoAtletaPorIdEvento : IGetEventoAtletaPorIdEvento
    {
        private readonly IRepositorioEvento _repositorioEvento;
        public GetEventoAtletaPorIdEvento(IRepositorioEvento repositorioEvento)
        {
            _repositorioEvento = repositorioEvento;
        }
        public List<EventoAtletaDto> Ejecutar(int idEvento)
        {
            Evento eventoTraido = _repositorioEvento.GetEventoPorId(idEvento);

            List<EventoAtletaDto> eventoAtletaDto = new List<EventoAtletaDto>();

            foreach (var eventoAtleta in eventoTraido.EventoAtletas)
                eventoAtletaDto.Add(new EventoAtletaDto(eventoAtleta));

            return eventoAtletaDto;
        }
    }
}
