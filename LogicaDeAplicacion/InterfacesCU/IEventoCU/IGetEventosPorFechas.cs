using Dto;

namespace LogicaDeAplicacion.InterfacesCU.IEventoCU
{
    public interface IGetEventosPorFechas
    {
        public List<EventoDto> Ejecutar(DateTime fechaInicio, DateTime fechaFin);
    }
}
