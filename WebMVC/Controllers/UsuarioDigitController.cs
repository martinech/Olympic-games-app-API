using LogicaDeAplicacion.InterfacesCU.IAtletaCU;
using LogicaDeAplicacion.InterfacesCU.IDisciplinaCU;
using LogicaDeNegocio.Entidades;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;
using Dto;

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
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public IActionResult GetDisciplinas(int id)
        {
            AtletaDto atletaDto = _getAtletaPorId.Ejecutar(id);

            if (atletaDto == null)
            {
                TempData["ErrorAtleta"] = "Operacion Invalida";
                return RedirectToAction("GestionDeAtletas");
            }
            var disciplinas = _getDisciplinas.Ejecutar();

            GestionDisciplinasViewModel disciplinasVM = new GestionDisciplinasViewModel
            {
                Atleta = atletaDto,
                Disciplinas = disciplinas.Where(d => !atletaDto.DisciplinasDto.Select(ad => ad.Nombre).Contains(d.Nombre))
            };
            return View(disciplinasVM);
        }

        [HttpGet]
        public IActionResult GestionDeDisciplinas()
        {
            if (HttpContext.Session.GetString("rolLogueado") == "digit")
            {
                IEnumerable<DisciplinaDto> disciplinas = _getDisciplinas.Ejecutar();

                if (!disciplinas.Any())
                {
                    ViewBag.mensaje = "No hay disciplinas para mostrar";
                    return View();
                }
                GestionDisciplinasViewModel disciplinasVM = new GestionDisciplinasViewModel();
                disciplinasVM.Disciplinas = disciplinas;
                return View(disciplinasVM);
            }
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
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

            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public IActionResult CrearDisciplina(DisciplinaDto disciplinaDto)
        {
            string emailUsuario = HttpContext.Session.GetString("emailLogueado");
            OperacionCRUD operacion = _crearDisciplina.Ejecutar(disciplinaDto, emailUsuario);

            if (operacion.FueExitosa)
                return RedirectToAction("GestionDeDisciplinas");

            ViewBag.mensaje = operacion.Mensaje;
            return View();
        }

        [HttpGet]
        public IActionResult ModificarDisciplina(int id)
        {
            if (HttpContext.Session.GetString("rolLogueado") == "digit")
            {
                DisciplinaDto disciplinaDto = _getDisciplinaPorId.Ejecutar(id);
                if(disciplinaDto == null)
                {
                    TempData["ErrorDeId"] = "Operacion Invalida";
                    return RedirectToAction("GestionDeDisciplinas");
                }
                return View(disciplinaDto);
            }
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public IActionResult ModificarDisciplina(int id, DisciplinaDto disciplinaDto)
        {
            string emailUsuario = HttpContext.Session.GetString("emailLogueado");
            OperacionCRUD operacion = _modificarDisciplina.Ejecutar(id, disciplinaDto, emailUsuario);

            if (operacion.FueExitosa)
                return RedirectToAction("GestionDeDisciplinas");

            ViewBag.mensaje = operacion.Mensaje;
            return View();
        }
        
        [HttpGet]
        public IActionResult EliminarDisciplina(int id)
        {
            if (HttpContext.Session.GetString("rolLogueado") == "digit")
            {
                DisciplinaDto disciplinaDto = _getDisciplinaPorId.Ejecutar(id);
                if (disciplinaDto == null)
                {
                    TempData["ErrorDeId"] = "Operacion Invalida";
                    return RedirectToAction("GestionDeDisciplinas");
                }
                return View(disciplinaDto);
            }
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public IActionResult EliminarDisciplina(int id, Disciplina disciplinaDto)
        {
            if (HttpContext.Session.GetString("rolLogueado") == "digit")
            {
                string emailUsuario = HttpContext.Session.GetString("emailLogueado");
                _eliminarDisciplina.Ejecutar(id, emailUsuario);
                return RedirectToAction("GestionDeDisciplinas");
            }
            else
                return RedirectToAction("Index", "Home");
        }
    }
}
