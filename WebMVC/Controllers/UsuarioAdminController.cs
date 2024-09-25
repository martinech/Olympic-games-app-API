using Dto;
using LogicaDeAplicacion.InterfacesCU.IUsuarioCU;
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


        public UsuarioAdminController(  ICrearUsuario crearUsuario,
                                        IEliminarUsuario eliminarUsuario,
                                        IGetUsuarioPorId getUsuarioPorId,
                                        IModificarUsuario modificarUsuario,
                                        IGetUsuarios getUsuarios)

        {
            _crearUsuario = crearUsuario;
            _eliminarUsuario = eliminarUsuario;
            _getUsuarioPorId = getUsuarioPorId;
            _getUsuarios = getUsuarios;
            _modificarUsuario = modificarUsuario;

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
                return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult CrearUsuario()
        {
            if (HttpContext.Session.GetString("rolLogueado") == "admin")
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult CrearUsuario(string email, string password, string rol)
        {
            if (HttpContext.Session.GetString("rolLogueado") == "admin")
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
                return RedirectToAction("GestionDeUsuarios");
            }
            else
                return RedirectToAction("Index", "Home");         
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
                return RedirectToAction("Index", "Home");  
        }

        [HttpPost]
        public IActionResult ModificarUsuario(int id, UsuarioDto usuarioDto)
        {
            if (HttpContext.Session.GetString("rolLogueado") == "admin")
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
            else
                return RedirectToAction("Index", "Home");
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
                return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult Eliminar(int id, UsuarioDto usuarioDto)
        {
            if (HttpContext.Session.GetString("rolLogueado") == "admin")
            {
                _eliminarUsuario.Ejecutar(id);
                return RedirectToAction("GestionDeUsuarios");
            }
            else
                return RedirectToAction("Index", "Home");
        }
    }
}
