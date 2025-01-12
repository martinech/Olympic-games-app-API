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
                                        IGetEventos getEventos)
            

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
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
            
        }

        [HttpGet]
        public IActionResult CrearUsuario()
        {
            if (HttpContext.Session.GetString("rolLogueado") == "admin")
                return View();

            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public IActionResult CrearUsuario(UsuarioDto usuarioDto)
        {
            OperacionConUsuario operacion = _crearUsuario.Ejecutar(usuarioDto);
            if (operacion.Exitosa)
                return RedirectToAction("GestionDeUsuarios");

            ViewBag.mensaje = operacion.Mensaje;
            return View();
        }   

        [HttpGet]
        public IActionResult ModificarUsuario(int id)
        {
            if (HttpContext.Session.GetString("rolLogueado") == "admin")
            {
                UsuarioDto usuarioDto = _getUsuarioPorId.Ejecutar(id);
                if(usuarioDto is not null)
                    return View(usuarioDto);

                TempData["ErrorOperacion"] = "Operacion invalida";
                return RedirectToAction("GestionDeUsuarios");
            }
            return RedirectToAction("Logout", "AmbosUsuarios");
        }

        [HttpPost]
        public IActionResult ModificarUsuario(int id, UsuarioDto usuarioDto)
        {
            OperacionConUsuario operacion = _modificarUsuario.Ejecutar(id, usuarioDto);

            if (operacion.Exitosa)
                return RedirectToAction("GestionDeUsuarios");

            ViewBag.mensaje = operacion.Mensaje;
            return View();
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            if (HttpContext.Session.GetString("rolLogueado") == "admin")
            {
                UsuarioDto usuarioDto = _getUsuarioPorId.Ejecutar(id);
                if (usuarioDto is not null)
                    return View(usuarioDto);

                TempData["ErrorOperacion"] = "Operacion invalida";
                return RedirectToAction("GestionDeUsuarios");
            }
            return RedirectToAction("Logout", "AmbosUsuarios");
        }

        [HttpPost]
        public IActionResult Eliminar(int id, UsuarioDto usuarioDto)
        {
            _eliminarUsuario.Ejecutar(id);
            return RedirectToAction("GestionDeUsuarios");
        }

        [HttpPost]
        public IActionResult CrearEvento(string nombre, string disciplina, DateTime fechaInicio, DateTime fechaFin)
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
