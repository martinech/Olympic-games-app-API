using LogicaDeAplicacion.InterfacesCU.IAtletaCU;
using LogicaDeNegocio.InterfacesRepositorios;
using Dto;

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
            if (!_repositorioAtleta.ExisteAtletaPorId(id))
                return null;

            AtletaDto atletaDto = new AtletaDto(_repositorioAtleta.GetAtletaPorId(id));
            return atletaDto;
        }
    }
}
