using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;
using Dto;
using LogicaDeNegocio.Exceptions;
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

        public UsuarioDigitController(  IGetAtletas getAtletas,
                                        ICrearAtleta crearAtleta,
                                        IGetAtletaPorId getAtletaPorId,
                                        IModificarAtleta modificarAtleta,
                                        IGetDisciplinas getDisciplinas)

        {
            _getAtletas = getAtletas;
            _crearAtleta = crearAtleta;
            _getAtletaPorId = getAtletaPorId;
            _modificarAtleta = modificarAtleta;
            _getDisciplinas = getDisciplinas;
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
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public IActionResult GetDisciplinas(int id)
        {
            GestionDisciplinasViewModel disciplinasVM = new GestionDisciplinasViewModel();
            disciplinasVM.Disciplinas = _getDisciplinas.Ejecutar();
            disciplinasVM.Atleta = _getAtletaPorId.Ejecutar(id);
            return View(disciplinasVM);
        }
    }
}
