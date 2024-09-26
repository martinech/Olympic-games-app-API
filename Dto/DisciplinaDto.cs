using LogicaDeNegocio.Entidades;

namespace Dto
{
    public class DisciplinaDto
    {
        public int Id { get; set; }
        public Nombre Nombre { get; set; }
        public int AnioDeIntegracion { get; set; }
        public List<Atleta> Atletas { get; set; } = new List<Atleta>();

        public DisciplinaDto() { }

        public DisciplinaDto(Disciplina disciplina)
        {
            Id = disciplina.Id;
            Nombre = disciplina.Nombre;
            AnioDeIntegracion = disciplina.AnioDeIntegracion;
            Atletas = disciplina.Atletas;
        }

        public Disciplina ToDisciplina()
        {
            Disciplina disciplina = new Disciplina()
            {
                Id = Id,
                Nombre = Nombre,
                AnioDeIntegracion = AnioDeIntegracion,
                Atletas = Atletas
            };
            return disciplina;
        }
    }
}
