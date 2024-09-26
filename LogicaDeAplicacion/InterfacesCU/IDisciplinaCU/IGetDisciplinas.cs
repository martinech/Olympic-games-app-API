using Dto;

namespace LogicaDeAplicacion.InterfacesCU.IDisciplinaCU
{
    public interface IGetDisciplinas
    {
        public IEnumerable<DisciplinaDto> Ejecutar(); 
    }
}
