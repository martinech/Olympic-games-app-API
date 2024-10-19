using Dto;
using LogicaDeAplicacion.InterfacesCU.IAtletaCU;
using LogicaDeNegocio.InterfacesRepositorios;

namespace LogicaDeAplicacion.ImplementacionCU.AtletaCU
{
    public class GetAtletasPorDisciplina : IGetAtletasPorDisciplina
    {
        private readonly IRepositorioAtleta _repositorioAtleta;

        public GetAtletasPorDisciplina(IRepositorioAtleta repositorioAtleta)
        {
            _repositorioAtleta = repositorioAtleta;
        }
        public List<AtletaDto> Ejecutar(int idDisciplina)
        {
            List<AtletaDto> atletasPorDisciplina = new List<AtletaDto>();

            foreach (var atleta in _repositorioAtleta.GetAtletasPorDisciplina(idDisciplina))
                atletasPorDisciplina.Add(new AtletaDto(atleta));

            return atletasPorDisciplina;
        }
    }
}
