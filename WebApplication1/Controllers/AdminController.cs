using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        Sistema unS = Sistema.Instancia;

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListarPasajes()
        {
            if (HttpContext.Session.GetString("Usuario") == null) return Redirect("/Login/Login");
            if(HttpContext.Session.GetString("Rol")== "Administrador")
            {
                ViewBag.Pasajes = unS.DevolverPasajesOrdenadosPorFecha();
                return View();
            }
            else
            {
                ViewBag.error = "Acceso no autorizado";
            }
                return View("Index");
        }

        public IActionResult ListarClientes()
        {
            if (HttpContext.Session.GetString("Usuario") == null) return Redirect("/Login/Login");
            if (HttpContext.Session.GetString("Rol") != "Administrador")
            {
                TempData["Error"] = "Acceso no autorizado";
                return RedirectToAction("Index");
            }

            ViewBag.Clientes = unS.ObtenerClientesOrdenados();
            return View();
        }

        [HttpPost]
        public IActionResult EditarCliente(string correo, int? puntos, bool? elegible)
        {
            Cliente? cli = unS.DevolverCliente(correo);
            if (cli != null)
            {
                if (cli is Premium p && puntos != null)
                {
                    p.Puntos = puntos.Value;
                }
                else if (cli is Ocasional o && elegible != null)
                {
                    o.RegalosDeCabina = elegible.Value;
                }
            }

            return RedirectToAction("ListarClientes");
        }
    }
}
