using Dto;
namespace LogicaDeAplicacion.InterfacesCU.IEventoCU
{
    public interface IGetEventos
    {
        IEnumerable<EventoDto> Ejecutar();
    }
}
