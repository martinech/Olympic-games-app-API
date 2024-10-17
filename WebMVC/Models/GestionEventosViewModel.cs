using Dto;

namespace WebMVC.Models
{
    public class GestionEventosViewModel
    {
        public IEnumerable<EventoDto> Eventos { get; set; }
        public IEnumerable<AtletaDto> Atletas { get; set; }
    }
}
