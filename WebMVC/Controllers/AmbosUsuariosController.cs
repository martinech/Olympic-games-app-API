using Dto;
using LogicaDeAplicacion.InterfacesCU.IUsuarioCU;
using LogicaDeAplicacion.InterfacesCU.IEventoCU;
using LogicaDeAplicacion.InterfacesCU.IDisciplinaCU;
using LogicaDeAplicacion.InterfacesCU.IAtletaCU;
using LogicaDeNegocio.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class AmbosUsuariosController : Controller
    {
        private readonly ILogger<AmbosUsuariosController> _logger;
        private readonly ILoginUsuario _loginUsuario;
        private readonly IGetEventos _getEventos;
        private readonly IGetDisciplinas _getDisciplinas;
        private readonly IGetAtletasPorDisciplina _getAtletasPorDisciplina;
        private readonly IGetDisciplinaPorId _getDisciplinaPorId;
        private readonly ICrearEvento _crearEvento;

        public AmbosUsuariosController( ILogger<AmbosUsuariosController> logger, 
                                        ILoginUsuario loginUsuario,
                                        IGetEventos getEventos,
                                        IGetDisciplinas getDisciplinas,
                                        IGetAtletasPorDisciplina getAtletasPorDisciplina,
                                        IGetDisciplinaPorId getDisciplinaPorId,
                                        ICrearEvento crearEvento)

        {
            _logger = logger;
            _loginUsuario = loginUsuario;
            _getEventos = getEventos;
            _getDisciplinas = getDisciplinas;
            _getAtletasPorDisciplina = getAtletasPorDisciplina;
            _getDisciplinaPorId = getDisciplinaPorId;
            _crearEvento = crearEvento;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            try
            {
                UsuarioDto usuarioLogueado = _loginUsuario.Ejecutar(email, password);
                HttpContext.Session.SetInt32("idLogueado", usuarioLogueado.Id);
                HttpContext.Session.SetString("emailLogueado", usuarioLogueado.Email);
                HttpContext.Session.SetString("rolLogueado", usuarioLogueado.Rol);

                if (HttpContext.Session.GetString("rolLogueado") == "admin")
                    return RedirectToAction("GestionDeUsuarios", "UsuarioAdmin");
                else
                    return RedirectToAction("GestionDeAtletas", "UsuarioDigit");
            }
            catch (UsuarioInvalidoException e)
            {
                ViewBag.mensaje = e.Message;
                return View();
            }
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        //EVENTOS
        [HttpGet]
        public IActionResult GestionDeEventos()
        {
            if (HttpContext.Session.GetString("rolLogueado") == "admin" || HttpContext.Session.GetString("rolLogueado") == "digit")
            {
                GestionEventosViewModel model = new GestionEventosViewModel();
                model.Eventos = _getEventos.Ejecutar();
                return View(model);
            }
            else
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpGet]
        public IActionResult CrearEvento()
        {
            if (HttpContext.Session.GetString("rolLogueado") == "admin" || HttpContext.Session.GetString("rolLogueado") == "digit")
            {
                CrearEventoViewModel crearEventoVM = new CrearEventoViewModel();
                crearEventoVM.disciplinas = _getDisciplinas.Ejecutar();
                return View(crearEventoVM);
            }
            else
                return RedirectToAction("Login", "Home");
        }

        [HttpGet, HttpPost]
        public IActionResult CrearEvento2(string nombreEvento, int idDisciplina)
        {
            TempData["nombreEvento"] = nombreEvento;
            TempData["idDisciplina"] = idDisciplina;
            CrearEventoViewModel crearEventoVM = new CrearEventoViewModel();
            crearEventoVM.atletas = _getAtletasPorDisciplina.Ejecutar(idDisciplina);
            return View(crearEventoVM);
        }

        [HttpPost]
        public IActionResult CrearEvento3(DateTime fechaInicio, DateTime fechaFinal)
        {
            try 
            {
                DisciplinaDto disciplinaDto = _getDisciplinaPorId.Ejecutar((int)TempData["idDisciplina"]);
                EventoDto eventoDto = new EventoDto()
                {
                    Nombre = (string)TempData["nombreEvento"],
                    Disciplina = disciplinaDto.Nombre,
                    FechaInicio = fechaInicio,
                    FechaFin = fechaFinal
                };
                _crearEvento.Ejecutar(eventoDto);
            }
            catch(Exception e)
            {
                TempData["nombreEventoRepetido"] = e.Message;
                return RedirectToAction("CrearEvento2");
            }
            return RedirectToAction("GestionDeEventos");
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
