using Dto;
using LogicaDeAplicacion.InterfacesCU.IUsuarioCU;
using LogicaDeAplicacion.InterfacesCU.IEventoCU;
using LogicaDeAplicacion.InterfacesCU.IDisciplinaCU;
using LogicaDeAplicacion.InterfacesCU.IAtletaCU;
using LogicaDeNegocio.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMVC.Models;
using LogicaDeNegocio.Entidades;

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
        private readonly IAsignarAtletaAEvento _asignarAtletaAEvento;
        private readonly IGetEventosPorFecha _getEventosPorFecha;
        private readonly IGetEventoAtletaPorIdEvento _getEventoAtletaPorIdEvento;
        private readonly IGetAtletaPorId _getAtletaPorId;
        private readonly IGetEventoPorId _getEventoPorId;
        private readonly IAsignarPuntaje _asignarPuntaje;

        public AmbosUsuariosController(ILogger<AmbosUsuariosController> logger,
                                        ILoginUsuario loginUsuario,
                                        IGetEventos getEventos,
                                        IGetDisciplinas getDisciplinas,
                                        IGetAtletasPorDisciplina getAtletasPorDisciplina,
                                        IGetDisciplinaPorId getDisciplinaPorId,
                                        ICrearEvento crearEvento,
                                        IAsignarAtletaAEvento asignarAtletaAEvento,
                                        IGetEventosPorFecha getEventosPorFecha,
                                        IGetEventoAtletaPorIdEvento getEventoAtletaPorIdEvento,
                                        IGetAtletaPorId getAtletaPorId,
                                        IGetEventoPorId getEventoPorId,
                                        IAsignarPuntaje asignarPuntaje)
        {
            _logger = logger;
            _loginUsuario = loginUsuario;
            _getEventos = getEventos;
            _getDisciplinas = getDisciplinas;
            _getAtletasPorDisciplina = getAtletasPorDisciplina;
            _getDisciplinaPorId = getDisciplinaPorId;
            _crearEvento = crearEvento;
            _asignarAtletaAEvento = asignarAtletaAEvento;
            _getEventosPorFecha = getEventosPorFecha;
            _getEventoAtletaPorIdEvento = getEventoAtletaPorIdEvento;
            _getAtletaPorId = getAtletaPorId;
            _getEventoPorId = getEventoPorId;
            _asignarPuntaje = asignarPuntaje;
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
                HttpContext.Session.SetString("token", usuarioLogueado.token);

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
                if (TempData["nombreEventoRepetido"] != null)
                {
                    ViewBag.ErrorMensaje = TempData["nombreEventoRepetido"].ToString();
                }
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
        public IActionResult CrearEvento3(List<int> AtletasSeleccionados, DateTime fechaInicio, DateTime fechaFinal)
        {
            if (fechaInicio == DateTime.MinValue || fechaFinal == DateTime.MinValue)
            {
                ViewBag.ErrorMensaje = "Debe ingresar una fecha de inicio y finalización válida.";
                CrearEventoViewModel crearEventoVM = new CrearEventoViewModel();
                string NombreEvento = TempData["nombreEvento"]?.ToString();
                int idDisciplina = (int)TempData["idDisciplina"];
                crearEventoVM.atletas = _getAtletasPorDisciplina.Ejecutar(idDisciplina);
                TempData.Keep("nombreEvento");
                TempData.Keep("idDisciplina");

                return View("CrearEvento2", crearEventoVM);
            } else if (AtletasSeleccionados.Count < 3) {
                ViewBag.ErrorMensaje = "Debe ingresar al menos 3 atletas";
                CrearEventoViewModel crearEventoVM = new CrearEventoViewModel();
                string NombreEvento = TempData["nombreEvento"]?.ToString();
                int idDisciplina = (int)TempData["idDisciplina"];
                crearEventoVM.atletas = _getAtletasPorDisciplina.Ejecutar(idDisciplina);
                TempData.Keep("nombreEvento");
                TempData.Keep("idDisciplina");
                return View("CrearEvento2", crearEventoVM);
            }
            else
            {
                try
                {
                    string NombreEvento = TempData["nombreEvento"]?.ToString();
                    int idDisciplina = (int)TempData["idDisciplina"];
                    CrearEventoViewModel crearEventoVM = new CrearEventoViewModel();
                    crearEventoVM.atletas = _getAtletasPorDisciplina.Ejecutar(idDisciplina);
                    DisciplinaDto disciplinaDto = _getDisciplinaPorId.Ejecutar(idDisciplina);
                    EventoDto eventoDto = new EventoDto()
                    {
                        Nombre = (string)TempData["nombreEvento"],
                        Disciplina = disciplinaDto.Nombre,
                        FechaInicio = fechaInicio,
                        FechaFin = fechaFinal
                    };
                    int eventoId = _crearEvento.Ejecutar(eventoDto);
                    foreach (var atletaId in AtletasSeleccionados)
                    {
                        var eventoAtletaDto = new EventoAtletaDto
                        {
                            idAtleta = atletaId,
                            idEvento = eventoId,
                            Puntaje = 0
                        };
                        _asignarAtletaAEvento.Ejecutar(eventoAtletaDto);
                    }

                    return RedirectToAction("GestionDeEventos");
                }
                catch (Exception e)
                {
                    TempData["nombreEventoRepetido"] = e.Message;
                    return RedirectToAction("CrearEvento");

                }
            }
        }
        [HttpGet, HttpPost]
        public IActionResult GetEventosPorFecha(DateTime fechaEvento)
        {
            BuscarEventosPorFechaViewModel buscarEventosVM = new BuscarEventosPorFechaViewModel();
            buscarEventosVM.Eventos = _getEventosPorFecha.Ejecutar(fechaEvento);
            return View(buscarEventosVM);
        }

        [HttpGet]
        public IActionResult GetAtletasEvento(int id)
        {
            EventoAtletaViewModel eventoAtletaVM = new EventoAtletaViewModel();
            eventoAtletaVM.atletaEnElEvento = _getEventoAtletaPorIdEvento.Ejecutar(id);
            ViewBag.idEvento = id;
            return View(eventoAtletaVM);
        }

        [HttpGet]
        public IActionResult AsignarPuntaje(int idAtleta, int idEvento)
        {
            if (HttpContext.Session.GetString("rolLogueado") == "admin" || HttpContext.Session.GetString("rolLogueado") == "digit")
            {
                try
                {
                    ViewBag.idEvento = idEvento;
                    ViewBag.idAtleta = idAtleta;

                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMensaje = "Ocurrió un error al cargar los datos.";
                    return RedirectToAction("GestionDeEventos");
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public IActionResult AsignarPuntaje(int idAtleta, int idEvento, int Puntaje)
        {
            if (HttpContext.Session.GetString("rolLogueado") == "admin" || HttpContext.Session.GetString("rolLogueado") == "digit")
            {
                try
                {
                    EventoAtletaDto eventoAtleta = new EventoAtletaDto
                    {
                        idAtleta = idAtleta,
                        idEvento = idEvento,
                        Puntaje = Puntaje
                    };

                    _asignarPuntaje.Ejecutar(idEvento, idAtleta, eventoAtleta);

                    return RedirectToAction("GetAtletasEvento", new { id = idEvento });
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMensaje = "Ocurrió un error al asignar el puntaje.";
                    return RedirectToAction("GestionDeEventos");
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
