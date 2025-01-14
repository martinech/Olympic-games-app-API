using Dto;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.InterfacesRepositorios;
using LogicaDeAplicacion.InterfacesCU.IAtletaCU;

namespace LogicaDeAplicacion.ImplementacionCU
{
    public class CrearDisciplina : ICrearDisciplina
    {
        private readonly IRepositorioDisciplina _repositorioDisciplina;

        public CrearDisciplina(IRepositorioDisciplina repositorio)
        {
            _repositorioDisciplina = repositorio;
        }
        public OperacionCRUD Ejecutar(DisciplinaDto disciplinaDto, string emailUsuario)
        {
            OperacionCRUD operacion = new OperacionCRUD();

            if (!_repositorioDisciplina.YaExisteDisciplinaConEseNombre(disciplinaDto.Nombre.ToString()))
            {
                Disciplina disciplinaNuevo = disciplinaDto.ToDisciplina();
                disciplinaNuevo.Validar();
                _repositorioDisciplina.Crear(disciplinaNuevo, emailUsuario);
                operacion.FueExitosa = true;
                return operacion;
            }
            operacion.FueExitosa = false;
            operacion.Mensaje = "Ya existe una disciplina con ese nombre";
            return operacion;
            
        }
    }
}
