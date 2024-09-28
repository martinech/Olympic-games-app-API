using LogicaDeNegocio.Entidades;

namespace Dto
{
    public class DisciplinaDto
    {
        public int Id { get; set; }
        public Nombre Nombre { get; set; }
        public int AnioDeIntegracion { get; set; }
        public List<AtletaDto> AtletasDto { get; set; } = new List<AtletaDto>();

        public DisciplinaDto() { }

        public DisciplinaDto(Disciplina disciplina)
        {
            Id = disciplina.Id;
            Nombre = disciplina.Nombre;
            AnioDeIntegracion = disciplina.AnioDeIntegracion;
            AtletasDto = AtletasToAtletasDto(disciplina.Atletas);
        }

        public List<AtletaDto> AtletasToAtletasDto(List<Atleta> atletas)
        {
            List<AtletaDto> atletasDto = new List<AtletaDto>();

            foreach (Atleta atleta in atletas)
                atletasDto.Add(new AtletaDto(atleta));

            return atletasDto;
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
                Nombre = Nombre,
                AnioDeIntegracion = AnioDeIntegracion,
                Atletas = AtletasDtoToAtletas()
            };
            return disciplina;
        }
    }
}
