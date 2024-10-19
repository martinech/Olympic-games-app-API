using Dto;

namespace WebMVC.Models
{
    public class CrearEventoViewModel
    {
        public IEnumerable<DisciplinaDto> disciplinas { get; set; }
        public IEnumerable<AtletaDto> atletas { get; set; }
    }
}
