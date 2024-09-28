using Dto;

namespace LogicaDeAplicacion.InterfacesCU.IDisciplinaCU
{
    public interface IGetDisciplinaPorId
    {
        public DisciplinaDto Ejecutar(int id);
    }
}
