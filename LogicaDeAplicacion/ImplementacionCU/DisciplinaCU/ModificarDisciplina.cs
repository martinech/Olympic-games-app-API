using LogicaDeAplicacion.InterfacesCU.IAtletaCU;
using LogicaDeNegocio.InterfacesRepositorios;
using LogicaDeNegocio.Entidades;
using Dto;

namespace LogicaDeAplicacion.ImplementacionCU
{
    public class ModificarDisciplina : IModificarDisciplina
    {
        private readonly IRepositorioDisciplina _repositorioDisciplina;

        public ModificarDisciplina (IRepositorioDisciplina repositorio)
        {
            _repositorioDisciplina = repositorio;
        }

        public OperacionCRUD Ejecutar(int id, DisciplinaDto disciplinaDto, string emailUsuario)
        {
            Disciplina disciplina = disciplinaDto.ToDisciplina();
            OperacionCRUD operacion = new OperacionCRUD();

            if (!_repositorioDisciplina.YaExisteDisciplinaConEseNombre(disciplinaDto.Nombre))
            {
                _repositorioDisciplina.Modificar(id, disciplina, emailUsuario);
                operacion.FueExitosa = true;
                return operacion;
            }
            operacion.FueExitosa = false;
            operacion.Mensaje = "El nombre que intenta ingresar no esta disponible";
            return operacion;
        }
    }
}
