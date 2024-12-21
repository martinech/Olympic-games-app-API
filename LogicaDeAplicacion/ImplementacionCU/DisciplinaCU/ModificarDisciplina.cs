using LogicaDeNegocio.InterfacesRepositorios;
using Dto;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Exceptions;
using LogicaDeAplicacion.InterfacesCU.IAtletaCU;

namespace LogicaDeAplicacion.ImplementacionCU
{
    public class ModificarDisciplina : IModificarDisciplina
    {
        private readonly IRepositorioDisciplina _repositorioDisciplina;

        public ModificarDisciplina (IRepositorioDisciplina repositorio)
        {
            _repositorioDisciplina = repositorio;
        }

        public void Ejecutar(int id, DisciplinaDto disciplinaDto, string emailUsuario)
        {
            Disciplina disciplina = disciplinaDto.ToDisciplina();

            try
            {
                disciplina.Validar();
                _repositorioDisciplina.Modificar(id, disciplina, emailUsuario);
            }
            catch (DatoInvalidoException e)
            {
                throw;
            }
        }
    }
}
