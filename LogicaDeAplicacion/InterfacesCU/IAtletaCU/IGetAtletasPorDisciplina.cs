using Dto;

namespace LogicaDeAplicacion.InterfacesCU.IAtletaCU
{
    public interface IGetAtletasPorDisciplina
    {
        public List<AtletaDto> Ejecutar(int idDisciplina);
    }
}
