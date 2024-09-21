using Dto;
using LogicaDeAplicacion.InterfacesCU.IAtletaCU;
using LogicaDeNegocio.InterfacesRepositorios;

namespace LogicaDeAplicacion.ImplementacionCU.AtletaCU
{
    public class GetAtletaPorId : IGetAtletaPorId
    {
        private readonly IRepositorioAtleta _repositorioAtleta;

        public GetAtletaPorId(IRepositorioAtleta repositorio)
        {
            _repositorioAtleta = repositorio;
        }
        public AtletaDto Ejecutar(int id)
        {
            AtletaDto atletaDto = new AtletaDto(_repositorioAtleta.GetAtletaPorId(id));
            return atletaDto;
        }
    }
}
