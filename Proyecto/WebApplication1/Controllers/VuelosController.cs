using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class VuelosController : Controller
    {
        Sistema unS = Sistema.Instancia;
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Usuario") == null) return Redirect("/Login/Login");
            if (HttpContext.Session.GetString("Rol") != "Cliente")
            {
                TempData["Error"] = "Acceso no autorizado";
                return Redirect("/Admin/Index");
            }

            ViewBag.Vuelos = unS.DevolverVuelos();
            return View();
        }

        public IActionResult Comprar(string numero)
        {

            if (HttpContext.Session.GetString("Usuario") == null) return Redirect("/Login/Login");
            if (HttpContext.Session.GetString("Rol") != "Cliente")
            {
                TempData["Error"] = "Acceso no autorizado";
                return Redirect("/Admin/Index");
            }
         

            Vuelo? vuelo = unS.DevolverVueloPorNum(numero);
            if(vuelo == null)
            {
                ViewBag.error = "error numero de vuelo null";
            }
            ViewBag.Vuelo = vuelo;
            return View();
        }

        [HttpPost]
        public IActionResult Comprar(string numeroVuelo, DateTime fecha, Pasaje.TipoEquipaje equipaje, int cantidad)
        {
            try
            {
                if (HttpContext.Session.GetString("Rol") != "Cliente")
                {
                    TempData["Error"] = "Acceso no autorizado";
                    return Redirect("/Admin/Index");
                }

                string? correo = HttpContext.Session.GetString("Usuario");
                if (correo == null) return RedirectToAction("Login", "Login");

                Cliente? unU = unS.DevolverCliente(correo);
                
                Vuelo? vuelo = unS.DevolverVueloPorNum(numeroVuelo);

                if (vuelo == null)
                {
                    TempData["Error"] = "vuelo no encontrado.";
                    return RedirectToAction("Index");
                }

                if (!vuelo.Frecuencia.Contains(fecha.DayOfWeek))
                {
                    TempData["Error"] = "La fecha ingresada no coincide con la frecuencia del vuelo.";
                    return RedirectToAction("Index");
                }

                for (int i = 0; i < cantidad; i++)
                {
                    unS.EmitirPasaje(equipaje, vuelo, fecha, unU);
                }

                TempData["Exito"] = "compra realizada con exito.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Ocurrió un error al procesar la compra: " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        public IActionResult MisPasajes()
        {
            if (HttpContext.Session.GetString("Rol") != "Cliente")
            {
                TempData["Error"] = "Acceso no autorizado";
                return Redirect("/Admin/Index");
            }

            string? correo = HttpContext.Session.GetString("Usuario");
            if (correo == null) return RedirectToAction("Login", "Login");

            Cliente? cliente = unS.DevolverCliente(correo);
            if (cliente == null)
            {
                ViewBag.error = "Cliente no encontrado";
                return RedirectToAction("Login", "Login");
            }

            ViewBag.Pasajes = unS.DevolverPasajesPorCliente(cliente);
            return View();
        }

        public IActionResult VuelosFiltrados(string filtro)
        {
            string? correo = HttpContext.Session.GetString("Usuario");
            if (correo == null) return RedirectToAction("Login", "Login");

            List<Vuelo> lista = unS.VuelosPorRuta(filtro);
            ViewBag.vuelos = lista;
            if(lista.Count == 0)
            {
                ViewBag.error = "lista vacia";
            }
            return View("index");
        }

    }
    
}
