using Dto;
using LogicaDeNegocio.InterfacesRepositorios;
using LogicaDeNegocio.Entidades;
using LogicaDeAplicacion.InterfacesCU.IDisciplinaCU;
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
        public void Ejecutar(DisciplinaDto disciplinaDto, string emailUsuario)
        {
            Disciplina disciplinaNuevo = disciplinaDto.ToDisciplina();
            disciplinaNuevo.Validar();
            _repositorioDisciplina.Crear(disciplinaNuevo, emailUsuario);
        }
    }
}
