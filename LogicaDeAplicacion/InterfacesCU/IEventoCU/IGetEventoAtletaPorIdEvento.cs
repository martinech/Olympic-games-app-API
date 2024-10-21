using Dto;

namespace LogicaDeAplicacion.InterfacesCU.IEventoCU
{
    public interface IGetEventoAtletaPorIdEvento
    {
        public List<EventoAtletaDto> Ejecutar(int idEvento);
    }
}
