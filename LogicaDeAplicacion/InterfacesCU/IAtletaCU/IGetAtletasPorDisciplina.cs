using Dto;

namespace LogicaDeAplicacion.InterfacesCU.IAtletaCU
{
    public interface IGetAtletasPorDisciplina
    {
        public IEnumerable<AtletaDto> Ejecutar(int idDisciplina);
    }
}
