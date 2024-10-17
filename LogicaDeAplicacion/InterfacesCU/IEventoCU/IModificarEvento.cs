using Dto;

namespace LogicaDeAplicacion.InterfacesCU.IEventoCU
{
    public interface IModificarEvento
    {
        void Ejecutar(int id, EventoDto eventoDto);
    }
}
