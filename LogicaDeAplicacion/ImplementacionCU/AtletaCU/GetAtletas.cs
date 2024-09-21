using Dto;
using LogicaDeNegocio.InterfacesRepositorios;
using LogicaDeNegocio.Entidades;
using LogicaDeAplicacion.InterfacesCU.IAtletaCU;

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
            List<AtletaDto> atletasDto = new List<AtletaDto>();
            IEnumerable<Atleta> atletas = _repositorioAtleta.GetAtletas();

            foreach (Atleta u in atletas)
                atletasDto.Add(new AtletaDto(u));

            return atletasDto;
        }
    }
}
