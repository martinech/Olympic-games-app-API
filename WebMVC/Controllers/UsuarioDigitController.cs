using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;
using Dto;
using LogicaDeNegocio.Exceptions;
using LogicaDeAplicacion.InterfacesCU.IAtletaCU;

namespace WebMVC.Controllers
{
    public class UsuarioDigitController : Controller
    {
        private readonly IGetAtletas _getAtletas;
        private readonly ICrearAtleta _crearAtleta;
        private readonly IGetAtletaPorId _getAtletaPorId;
        private readonly IModificarAtleta _modificarAtleta;

        public UsuarioDigitController(  IGetAtletas getAtletas,
                                        ICrearAtleta crearAtleta,
                                        IGetAtletaPorId getAtletaPorId,
                                        IModificarAtleta modificarAtleta)

        {
            _getAtletas = getAtletas;
            _crearAtleta = crearAtleta;
            _getAtletaPorId = getAtletaPorId;
            _modificarAtleta = modificarAtleta;
        }

        [HttpGet]
        public IActionResult GestionDeAtletas()
        {
            if (HttpContext.Session.GetString("rolLogueado") != null &&
                HttpContext.Session.GetString("rolLogueado") == ("digit"))
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
        public IActionResult ModificarAtleta(int id)
        {
            if (HttpContext.Session.GetString("rolLogueado") != null &&
                HttpContext.Session.GetString("rolLogueado") == ("digit"))
            {
                AtletaDto atletaDto = _getAtletaPorId.Ejecutar(id);
                return View(atletaDto);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult ModificarAtleta(int id, AtletaDto atletaDto)
        {
            if (HttpContext.Session.GetString("rolLogueado") != null &&
                HttpContext.Session.GetString("rolLogueado") == ("digit"))
            {
                try
                {

                    _modificarAtleta.Ejecutar(id, atletaDto);

                }
                catch (DatoInvalidoException e)
                {
                    ViewBag.mensaje = e.Message;
                    return View();
                }
                return RedirectToAction("GestionDeAtletas");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
