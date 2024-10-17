using Dto;

namespace LogicaDeAplicacion.InterfacesCU.IEventoCU
{
    public interface IGetEventoPorId
    {
        EventoDto Ejecutar(int id);
    }
}
