using Dto;
using LogicaDeNegocio.InterfacesRepositorios;
using LogicaDeNegocio.Entidades;
using LogicaDeAplicacion.InterfacesCU.IAtletaCU;

namespace LogicaDeAplicacion.ImplementacionCU
{
    public class CrearAtleta : ICrearAtleta
    {
        private readonly IRepositorioAtleta _repositorioAtleta;

        public CrearAtleta(IRepositorioAtleta repositorio)
        {
            _repositorioAtleta = repositorio;
        }
        public void Ejecutar(AtletaDto atletaDto)
        {
            Atleta atletaNuevo = atletaDto.ToAtleta();
            atletaNuevo.Validar();
            _repositorioAtleta.Crear(atletaNuevo);
        }
    }
}
