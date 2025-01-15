using LogicaDeAplicacion.InterfacesCU.IAtletaCU;
using LogicaDeNegocio.InterfacesRepositorios;
using Dto;

namespace LogicaDeAplicacion.ImplementacionCU.AtletaCU
{
    public class GetAtletasPorDisciplina : IGetAtletasPorDisciplina
    {
        private readonly IRepositorioAtleta _repositorioAtleta;

        public GetAtletasPorDisciplina(IRepositorioAtleta repositorioAtleta)
        {
            _repositorioAtleta = repositorioAtleta;
        }

        public IEnumerable<AtletaDto> Ejecutar(int idDisciplina)
        {
            return _repositorioAtleta.GetAtletasPorDisciplina(idDisciplina).Select(atleta => new AtletaDto(atleta));
        }
    }
}
