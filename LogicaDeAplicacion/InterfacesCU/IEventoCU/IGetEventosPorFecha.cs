using Dto;

namespace LogicaDeAplicacion.InterfacesCU.IEventoCU
{
    public interface IGetEventosPorFecha
    {
        public List<EventoDto> Ejecutar(DateTime fecha);
    }
}
