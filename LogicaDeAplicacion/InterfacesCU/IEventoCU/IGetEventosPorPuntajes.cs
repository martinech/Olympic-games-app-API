using Dto;

namespace LogicaDeAplicacion.InterfacesCU.IEventoCU
{
    public interface IGetEventosPorPuntajes
    {
        public List<EventoDto> Ejecutar(int puntaje1, int puntaje2);
    }
}
