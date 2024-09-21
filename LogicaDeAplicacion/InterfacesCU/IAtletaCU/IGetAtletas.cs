using Dto;
namespace LogicaDeAplicacion.InterfacesCU.IAtletaCU
{
    public interface IGetAtletas
    {
        IEnumerable<AtletaDto> Ejecutar();
    }
}
