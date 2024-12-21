using Dto;

namespace LogicaAplicacion.InterfacesCU
{
    public interface IGetDisciplinasPorNombre
    {
        IEnumerable<DisciplinaDto> Ejecutar(string nombre);
    }
}
