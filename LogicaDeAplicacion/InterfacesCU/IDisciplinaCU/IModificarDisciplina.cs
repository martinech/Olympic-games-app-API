using Dto;

namespace LogicaDeAplicacion.InterfacesCU.IAtletaCU
{
    public interface IModificarDisciplina
    {
        void Ejecutar(int id, DisciplinaDto disciplinaDto, string emailUsuario);
    }
}
