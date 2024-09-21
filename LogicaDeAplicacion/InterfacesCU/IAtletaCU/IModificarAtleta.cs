using Dto;

namespace LogicaDeAplicacion.InterfacesCU.IAtletaCU
{
    public interface IModificarAtleta
    {
        void Ejecutar(int id, AtletaDto atletaDto);
    }
}
