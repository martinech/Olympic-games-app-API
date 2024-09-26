using Dto;

namespace WebMVC.Models
{
    public class GestionDisciplinasViewModel
    {
        public AtletaDto Atleta { get; set; }
        public IEnumerable<DisciplinaDto> Disciplinas { get; set; }
    }
}
