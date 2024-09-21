using Dto;

namespace LogicaDeAplicacion.InterfacesCU.IAtletaCU
{
    public interface IGetAtletaPorId
    {
        AtletaDto Ejecutar(int id);
    }
}
