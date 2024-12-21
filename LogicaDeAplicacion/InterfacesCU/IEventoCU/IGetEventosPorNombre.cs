using Dto;

namespace LogicaDeAplicacion.InterfacesCU.IEventoCU
{
    public interface IGetEventosPorNombre
    {
        List<EventoDto> Ejecutar(string nombre);
    }
}
