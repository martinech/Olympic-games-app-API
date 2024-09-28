using Dto;

namespace WebMVC.Models
{
    public class GestionDisciplinasViewModel
    {
        public AtletaDto AtletaDto { get; set; }
        public IEnumerable<DisciplinaDto> DisciplinasDto { get; set; }
    }
}
