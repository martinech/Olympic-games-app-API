using Dto;
using LogicaDeNegocio.Entidades;

namespace LogicaDeAplicacion.InterfacesCU.IAtletaCU
{
    public interface IModificarDisciplina
    {
        public OperacionCRUD Ejecutar(int id, DisciplinaDto disciplinaDto, string emailUsuario);
    }
}
