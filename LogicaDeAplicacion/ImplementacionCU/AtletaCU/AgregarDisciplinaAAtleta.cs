using LogicaDeAplicacion.InterfacesCU.IAtletaCU;
using LogicaDeNegocio.InterfacesRepositorios;
using LogicaDeNegocio.Entidades;

namespace LogicaDeAplicacion.ImplementacionCU.AtletaCU
{
    public class AgregarDisciplinaAAtleta : IAgregarDisciplinaAAtleta
    {
        private readonly IRepositorioAtleta _repositorioAtleta;
        private readonly IRepositorioDisciplina _repositorioDisciplina;

        public AgregarDisciplinaAAtleta(IRepositorioAtleta repositorioAtleta,
                                        IRepositorioDisciplina repositorioDisciplina)
        {
            _repositorioAtleta = repositorioAtleta;
            _repositorioDisciplina = repositorioDisciplina;
        }
        public void Ejecutar(int idAtleta, int idDisciplina)
        {
            Disciplina disciplina = _repositorioDisciplina.GetDisciplinaPorId(idDisciplina);
            Atleta atleta = _repositorioAtleta.GetAtletaPorId(idAtleta);
            atleta.Disciplinas.Add(disciplina);
            _repositorioAtleta.Modificar(idAtleta, atleta);
        }
    }
}
