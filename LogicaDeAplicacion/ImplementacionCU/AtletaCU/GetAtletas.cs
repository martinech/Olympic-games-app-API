using LogicaDeAplicacion.InterfacesCU.IAtletaCU;
using LogicaDeNegocio.InterfacesRepositorios;
using Dto;

namespace LogicaDeAplicacion.ImplementacionCU.AtletaCU
{
    public class GetAtletas : IGetAtletas
    {
        private readonly IRepositorioAtleta _repositorioAtleta;
        public GetAtletas(IRepositorioAtleta repositorio)
        {
            _repositorioAtleta = repositorio;
        }
        public IEnumerable<AtletaDto> Ejecutar()
        {
            return _repositorioAtleta.GetAtletas().Select(atleta => new AtletaDto(atleta));
        }
    }
}
