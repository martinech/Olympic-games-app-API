using Dto;
using LogicaDeAplicacion.InterfacesCU.IEventoCU;
using LogicaDeAplicacion.InterfacesCU.IUsuarioCU;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Exceptions;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class UsuarioAdminController : Controller
    {
        private readonly ICrearUsuario _crearUsuario;
        private readonly IEliminarUsuario _eliminarUsuario;
        private readonly IGetUsuarioPorId _getUsuarioPorId;
        private readonly IGetUsuarios _getUsuarios;
        private readonly IModificarUsuario _modificarUsuario;
        private readonly ICrearEvento _crearEvento;
        private readonly IEliminarEvento _eliminarEvento;
        private readonly IGetEventoPorId _getEventoPorId;
        private readonly IModificarEvento _modificarEvento;
        private readonly IGetEventos _getEventos;


        public UsuarioAdminController(  ICrearUsuario crearUsuario,
                                        IEliminarUsuario eliminarUsuario,
                                        IGetUsuarioPorId getUsuarioPorId,
                                        IModificarUsuario modificarUsuario,
                                        IGetUsuarios getUsuarios,
                                        ICrearEvento crearEvento,
                                        IEliminarEvento eliminarEvento,
                                        IGetEventoPorId getEventoPorId,
                                        IModificarEvento modificarEvento,
                                        IGetEventos getEventos
            )

        {
            _crearUsuario = crearUsuario;
            _eliminarUsuario = eliminarUsuario;
            _getUsuarioPorId = getUsuarioPorId;
            _getUsuarios = getUsuarios;
            _modificarUsuario = modificarUsuario;
            _crearEvento = crearEvento;
            _eliminarEvento = eliminarEvento;
            _getEventoPorId = getEventoPorId;
            _modificarEvento = modificarEvento;
            _getEventos = getEventos;
        }

        [HttpGet]
        public IActionResult GestionDeUsuarios()
        {
            if (HttpContext.Session.GetString("rolLogueado") == "admin")
            {
                UsuarioIndexViewModel model = new UsuarioIndexViewModel();
                model.Usuarios = _getUsuarios.Ejecutar();
                return View(model);
            }
            else
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpGet]
        public IActionResult CrearUsuario()
        {
            if (HttpContext.Session.GetString("rolLogueado") == "admin")
                return View();
            else
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public IActionResult CrearUsuario(string email, string password, string rol)
        {
            UsuarioDto nuevoUsuario = new UsuarioDto()
            {
                Email = email,
                Password = password,
                Rol = rol,
                FechaAlta = DateTime.Now,
                EmailAdministrador = HttpContext.Session.GetString("emailLogueado")
            };
            try
            {
                _crearUsuario.Ejecutar(nuevoUsuario);
            }
            catch (DatoInvalidoException e)
            {
                ViewBag.mensaje = e.Message;
                return View();
            }
            return RedirectToAction("GestionDeUsuarios");       
        }   

        [HttpGet]
        public IActionResult ModificarUsuario(int id)
        {
            if (HttpContext.Session.GetString("rolLogueado") == "admin")
            {
                UsuarioDto usuarioDto = _getUsuarioPorId.Ejecutar(id);
                return View(usuarioDto);
            }
            else
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public IActionResult ModificarUsuario(int id, UsuarioDto usuarioDto)
        {
            try
            {
                _modificarUsuario.Ejecutar(id, usuarioDto);
            }
            catch (DatoInvalidoException e)
            {
                ViewBag.mensaje = e.Message;
                return View();
            }
            return RedirectToAction("GestionDeUsuarios");
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            if (HttpContext.Session.GetString("rolLogueado") == "admin")
            {
                try
                {
                    UsuarioDto usuarioDto = _getUsuarioPorId.Ejecutar(id);
                    return View(usuarioDto);
                }
                catch (UsuarioInvalidoException e)
                {
                    TempData["MensajeError"] = e.Message;
                    return RedirectToAction("GestionDeUsuarios");
                }
            }
            else
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public IActionResult Eliminar(int id, UsuarioDto usuarioDto)
        {
            _eliminarUsuario.Ejecutar(id);
            return RedirectToAction("GestionDeUsuarios");
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
                return View();
            else
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public IActionResult CrearEvento(string nombre, Disciplina disciplina, DateTime fechaInicio, DateTime fechaFin)
        {
            EventoDto nuevoEvento = new EventoDto()
            {
                Nombre = nombre,
                Disciplina = disciplina,
                FechaInicio = fechaInicio,
                FechaFin = fechaFin
            };
            try
            {
                _crearEvento.Ejecutar(nuevoEvento);
            }
            catch (DatoInvalidoException e)
            {
                ViewBag.mensaje = e.Message;
                return View();
            }
            return RedirectToAction("GestionDeEventos");
        }

        [HttpGet]
        public IActionResult ModificarEvento(int id)
        {
            if (HttpContext.Session.GetString("rolLogueado") == "admin" || HttpContext.Session.GetString("rolLogueado") == "digit")
            {
                EventoDto eventoDto = _getEventoPorId.Ejecutar(id);
                return View(eventoDto);
            }
            else
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public IActionResult ModificarEvento(int id, EventoDto eventoDto)
        {
            try
            {
                _modificarEvento.Ejecutar(id, eventoDto);
            }
            catch (DatoInvalidoException e)
            {
                ViewBag.mensaje = e.Message;
                return View();
            }
            return RedirectToAction("GestionDeEventos");
        }

        [HttpGet]
        public IActionResult EliminarEvento(int id)
        {
            if (HttpContext.Session.GetString("rolLogueado") == "admin" || HttpContext.Session.GetString("rolLogueado") == "digit")
            {
                try
                {
                    EventoDto eventoDto = _getEventoPorId.Ejecutar(id);
                    return View(eventoDto);
                }
                catch (EventoInvalidoException e)
                {
                    TempData["MensajeError"] = e.Message;
                    return RedirectToAction("GestionDeEventos");
                }
            }
            else
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public IActionResult EliminarEvento(int id, EventoDto eventoDto)
        {
            _eliminarEvento.Ejecutar(id);
            return RedirectToAction("GestionDeEventos");
        }
    }
}
