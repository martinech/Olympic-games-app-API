using Dto;
using LogicaDeAplicacion.InterfacesCU.IAtletaCU;
using LogicaDeAplicacion.InterfacesCU.IDisciplinaCU;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Exceptions;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

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
        private readonly ICrearDisciplina _crearDisciplina;
        private readonly IEliminarDisciplina _eliminarDisciplina;
        private readonly IModificarDisciplina _modificarDisciplina;
        private readonly IAgregarDisciplinaAAtleta _agregarDisciplinaAAtleta;

        public UsuarioDigitController(IGetAtletas getAtletas,
                                        ICrearAtleta crearAtleta,
                                        IGetAtletaPorId getAtletaPorId,
                                        IModificarAtleta modificarAtleta,
                                        IGetDisciplinas getDisciplinas,
                                        IGetDisciplinaPorId getDisciplinaPorId,
                                        ICrearDisciplina crearDisciplina,
                                        IEliminarDisciplina eliminarDisciplina,
                                        IModificarDisciplina modificarDisciplina,
                                        IAgregarDisciplinaAAtleta agregarDisciplinaAAtleta)

        {
            _getAtletas = getAtletas;
            _crearAtleta = crearAtleta;
            _getAtletaPorId = getAtletaPorId;
            _modificarAtleta = modificarAtleta;
            _getDisciplinas = getDisciplinas;
            _getDisciplinaPorId = getDisciplinaPorId;
            _crearDisciplina = crearDisciplina;
            _eliminarDisciplina = eliminarDisciplina;
            _modificarDisciplina = modificarDisciplina;
            _agregarDisciplinaAAtleta = agregarDisciplinaAAtleta;
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

        [HttpGet]
        public IActionResult GetDisciplinas(int id)
        {
            try
            {
                GestionDisciplinasViewModel disciplinasVM = new GestionDisciplinasViewModel();
                disciplinasVM.DisciplinasDto = _getDisciplinas.Ejecutar();
                disciplinasVM.AtletaDto = _getAtletaPorId.Ejecutar(id);

                if (disciplinasVM.AtletaDto == null)
                {
                    // Maneja el caso en que no se encuentre el atleta
                    return RedirectToAction("Error", "Home", new { mensaje = "Atleta no encontrado" });
                }
                else
                {
                    return View(disciplinasVM);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener atleta: {ex.Message}");
                return RedirectToAction("Error", "Home", new { mensaje = "Se produjo un error inesperado" });
            }

        }

        [HttpGet]
        public IActionResult GestionDeDisciplinas()
        {
            try
            {
                GestionDisciplinasViewModel disciplinasVM = new GestionDisciplinasViewModel();
                disciplinasVM.DisciplinasDto = _getDisciplinas.Ejecutar();

                if (disciplinasVM.DisciplinasDto == null || !disciplinasVM.DisciplinasDto.Any())
                {
                    // Maneja el caso en que no se encuentren disciplinas
                    return RedirectToAction("Error", "Home", new { mensaje = "No hay disciplinas ingresadas" });
                }
                else
                {
                    return View(disciplinasVM);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener disciplinas {ex.Message}");
                return RedirectToAction("Error", "Home", new { mensaje = "Se produjo un error inesperado" });
            }
        }

        [HttpPost]
        public IActionResult AgregarDisciplinaAlAtleta(int idDisciplina, int idAtleta)
        {
            _agregarDisciplinaAAtleta.Ejecutar(idAtleta, idDisciplina);
            return RedirectToAction("GetDisciplinas", new { id = idAtleta });
        }
        [HttpGet]
        public IActionResult CrearDisciplina()
        {
            if (HttpContext.Session.GetString("rolLogueado") == "digit")
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult CrearDisciplina(string nombre, int anioDeIntegracion)
        {
            if (HttpContext.Session.GetString("rolLogueado") == "digit")
            {
                DisciplinaDto nuevaDisciplina = new DisciplinaDto()
                {
                    Nombre = new Nombre(nombre),
                    AnioDeIntegracion = anioDeIntegracion,
                };
                try
                {
                    _crearDisciplina.Ejecutar(nuevaDisciplina);
                }
                catch (UsuarioInvalidoException e)
                {
                    ViewBag.mensaje = e.Message;
                    return View();
                }
                catch (DatoInvalidoException e)
                {
                    ViewBag.mensage = e.Message;
                    return View();
                }
                return RedirectToAction("GestionDeDisciplinas");
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ModificarDisciplina(int id)
        {
            if (HttpContext.Session.GetString("rolLogueado") == "digit")
            {
                DisciplinaDto disciplinaDto = _getDisciplinaPorId.Ejecutar(id);
                return View(disciplinaDto);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult ModificarDisciplina(int id, DisciplinaDto disciplinaDto)
        {
            if (HttpContext.Session.GetString("rolLogueado") == "digit")
            {
                try
                {
                    _modificarDisciplina.Ejecutar(id, disciplinaDto);

                }
                catch (DatoInvalidoException e)
                {
                    ViewBag.mensaje = e.Message;
                    return View();
                }
                return RedirectToAction("GestionDeDisciplinas");
            }
            else
                return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult EliminarDisciplina(int id)
        {
            if (HttpContext.Session.GetString("rolLogueado") == "digit")
            {
                try
                {
                    DisciplinaDto disciplinaDto = _getDisciplinaPorId.Ejecutar(id);
                    return View(disciplinaDto);
                }
                catch (UsuarioInvalidoException e)
                {
                    TempData["MensajeError"] = e.Message;
                    return RedirectToAction("GestionDeUsuarios");
                }
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult EliminarDisciplina(int id, Disciplina disciplinaDto)
        {
            if (HttpContext.Session.GetString("rolLogueado") == "digit")
            {
                _eliminarDisciplina.Ejecutar(id);
                return RedirectToAction("GestionDeDisciplinas");
            }
            else
                return RedirectToAction("Index", "Home");
        }
    }
}
