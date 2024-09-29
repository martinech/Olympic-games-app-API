using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;
using Dto;
using LogicaDeAplicacion.InterfacesCU.IAtletaCU;
using LogicaDeAplicacion.InterfacesCU.IDisciplinaCU;

namespace WebMVC.Controllers
{
    public class UsuarioDigitController : Controller
    {
        private readonly IGetAtletas _getAtletas;
        private readonly ICrearAtleta _crearAtleta;
        private readonly IGetAtletaPorId _getAtletaPorId;
        private readonly IModificarAtleta _modificarAtleta;
        private readonly IGetDisciplinas _getDisciplinas;
        private readonly IGetDisciplinaPorId _getDisciplinaPorId;

        public UsuarioDigitController(  IGetAtletas getAtletas,
                                        ICrearAtleta crearAtleta,
                                        IGetAtletaPorId getAtletaPorId,
                                        IModificarAtleta modificarAtleta,
                                        IGetDisciplinas getDisciplinas,
                                        IGetDisciplinaPorId getDisciplinaPorId)

        {
            _getAtletas = getAtletas;
            _crearAtleta = crearAtleta;
            _getAtletaPorId = getAtletaPorId;
            _modificarAtleta = modificarAtleta;
            _getDisciplinas = getDisciplinas;
            _getDisciplinaPorId = getDisciplinaPorId;
        }

        [HttpGet]
        public IActionResult GestionDeAtletas()
        {
            if (HttpContext.Session.GetString("rolLogueado") == "digit")
            {
                GestionAtletasViewModel gestAtlViewModel = new GestionAtletasViewModel();
                gestAtlViewModel.Atletas = _getAtletas.Ejecutar();
                return View(gestAtlViewModel);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        //La ejecucion se corta porque en la linea 53, no carga al AtletaDto, las disciplinas de la linea 52 si, pero nunca llega al AletaDto.
        [HttpGet]
        public IActionResult GetDisciplinas(int id)
        {
            GestionDisciplinasViewModel disciplinasVM = new GestionDisciplinasViewModel();
            disciplinasVM.DisciplinasDto = _getDisciplinas.Ejecutar();
            disciplinasVM.AtletaDto = _getAtletaPorId.Ejecutar(id);
            return View(disciplinasVM);
        }

        [HttpPost]
        public IActionResult AgregarDisciplinaAlAtleta(int idDisciplina, int idAtleta)
        {
            DisciplinaDto disciplinaDto = _getDisciplinaPorId.Ejecutar(idDisciplina);
            AtletaDto atletaDto = _getAtletaPorId.Ejecutar(idAtleta);
            atletaDto.DisciplinasDto.Add(disciplinaDto);
            _modificarAtleta.Ejecutar(idAtleta, atletaDto);
            return RedirectToAction("GetDisciplinas");
        }
    }
}
