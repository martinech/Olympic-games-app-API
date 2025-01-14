using LogicaDeNegocio.Entidades;

namespace Dto
{
    public class DisciplinaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int AnioDeIntegracion { get; set; }
        public List<AtletaDto> AtletasDto { get; set; } = new List<AtletaDto>();

        public DisciplinaDto() { }

        public DisciplinaDto(Disciplina disciplina)
        {
            Id = disciplina.Id;
            Nombre = disciplina.Nombre.Disciplina.ToString();
            AnioDeIntegracion = disciplina.AnioDeIntegracion;
        }

        public List<Atleta> AtletasDtoToAtletas()
        {
            List<Atleta> atletas = new List<Atleta>();

            foreach (AtletaDto atletaDto in AtletasDto)
                atletas.Add(new Atleta()
                {
                    Id = atletaDto.Id,
                    Nombre = atletaDto.Nombre,
                    Apellido = atletaDto.Apellido,
                    Sexo = atletaDto.Sexo,
                    Pais = atletaDto.Pais,
                    Disciplinas = atletaDto.DisciplinasDtoADisciplinas()
                });

            return atletas;
        }

        public Disciplina ToDisciplina()
        {
            Disciplina disciplina = new Disciplina()
            {
                Id = Id,
                Nombre = new Nombre(Nombre),
                AnioDeIntegracion = AnioDeIntegracion,
            };
            return disciplina;
        }
    }
}
