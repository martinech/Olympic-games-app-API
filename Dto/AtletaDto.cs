using LogicaDeNegocio.Entidades;

namespace Dto
{
    public class AtletaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public string Pais { get; set; }
        public List<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();

        public AtletaDto() { }

        public AtletaDto(Atleta atleta)
        {
            Id = atleta.Id;
            Nombre = atleta.Nombre;
            Apellido = atleta.Apellido;
            Sexo = atleta.Sexo;
            Pais = atleta.Pais;
            Disciplinas = atleta.Disciplinas;
        }

        public Atleta ToAtleta()
        {
            Atleta atleta = new Atleta()
            {
                Id = Id,
                Nombre = Nombre,
                Apellido = Apellido,
                Sexo = Sexo,
                Pais = Pais,
                Disciplinas = Disciplinas
            };
            return atleta;
        }
    }
}
