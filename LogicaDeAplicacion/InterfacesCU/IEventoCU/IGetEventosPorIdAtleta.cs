using Dto;

namespace LogicaDeAplicacion.InterfacesCU.IEventoCU
{
    public interface IGetEventosPorIdAtleta
    {
        public List<EventoDto> Ejecutar(int idAtleta);
    }
}
