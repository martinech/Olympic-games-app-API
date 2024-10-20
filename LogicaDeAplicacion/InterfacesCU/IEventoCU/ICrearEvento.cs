using Dto;

namespace LogicaDeAplicacion.InterfacesCU.IEventoCU
{
    public interface ICrearEvento
    {
        int Ejecutar(EventoDto eventoDto);
    }
}
