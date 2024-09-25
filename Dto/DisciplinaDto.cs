using LogicaDeNegocio.Entidades;

namespace Dto
{
    public class DisciplinaDto
    {
        public int Id { get; set; }
        public Nombre Nombre { get; set; }
        public int AnioDeIntegracion { get; set; }
        public List<Atleta> Atletas { get; set; } = new List<Atleta>();
    }
}
