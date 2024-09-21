using Dto;
using LogicaDeAplicacion.InterfacesCU.IUsuarioCU;
using LogicaDeNegocio.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILoginUsuario _loginUsuario;

        public HomeController(ILogger<HomeController> logger, ILoginUsuario loginUsuario)
        {
            _logger = logger;
            _loginUsuario = loginUsuario;
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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
