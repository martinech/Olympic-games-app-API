using Dto;

namespace LogicaDeAplicacion.InterfacesCU.IEventoCU
{
    public interface IGetEventosPorDisciplina
    {
        public List<EventoDto> Ejecutar(int id);
    }
}
