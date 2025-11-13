using Microsoft.AspNetCore.Mvc;
using Dominio;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        Sistema unS = Sistema.Instancia;
 

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(Ocasional unC)
        {
            try
            {
                unS.AltaClienteOcasional(unC.Correo, unC.Contraseña, unC.Documento, unC.Nombre, unC.Nacionalidad);

                //traer de nuevo el usuario recien registrado
                Usuario? nuevoUsuario = unS.DevolverUsuario(unC.Correo, unC.Contraseña);

                if(nuevoUsuario != null)
                {
                    //loguearlo automaticamente
                    HttpContext.Session.SetString("Usuario", nuevoUsuario.Correo);
                    if (nuevoUsuario is Administrador) HttpContext.Session.SetString("Rol", "Administrador");
                    else if (nuevoUsuario is Cliente) HttpContext.Session.SetString("Rol", "Cliente");
                    
                    return RedirectToAction("Index", "Admin");
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
                return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string correo, string contraseña)
        {
            Usuario? unU = unS.DevolverUsuario(correo, contraseña);
            if(unU == null)
            {
                ViewBag.error = "Credenciales invalidas";
                return View();
            }
            else
            {
                HttpContext.Session.SetString("Usuario", unU.Correo);
                if (unU is Administrador) HttpContext.Session.SetString("Rol", "Administrador");
                else if (unU is Cliente) HttpContext.Session.SetString("Rol", "Cliente");

                return Redirect("/Admin/Index");   
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult Perfil()
        {

            if (HttpContext.Session.GetString("Rol") != "Cliente")
            {
                TempData["Error"] = "Acceso no autorizado";
                return Redirect("/Admin/Index");
            }

            string? correo = HttpContext.Session.GetString("Usuario");
            if (correo == null) return RedirectToAction("Login", "Login");

            Cliente? cliente = unS.DevolverCliente(correo);
            if(cliente == null)
            {
                TempData["Error"] = "no se encontro el cliente";
                return RedirectToAction("Login", "Login");
            }

            ViewBag.Cliente = cliente;
            return View();
        }
    }
}
