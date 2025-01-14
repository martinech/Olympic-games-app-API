using Dto;
using LogicaDeNegocio.Entidades;

namespace LogicaDeAplicacion.InterfacesCU.IAtletaCU
{
    public interface ICrearDisciplina
    {
        public OperacionCRUD Ejecutar(DisciplinaDto disciplinaDto, string emailUsuario);
    }
}
