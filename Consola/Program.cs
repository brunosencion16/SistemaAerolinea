using Dominio;
using System.ComponentModel.Design;

namespace Consola
{
    internal class Program
    {
        static Sistema unS = Sistema.Instancia;

        static void Main(string[] args)
        {
            int opcion = -1;

            string[] opciones = { "Opcion 1", "Opcion 2", "Opcion 3", "Opcion 4" };


            do
            {
                Menu(opciones);
                opcion = Utils.PedirNumero("Opcion");
                switch (opcion)
                {
                    case 1:
                        Opcion1();
                        Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 2:
                        Opcion2();
                        Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 3:
                        Opcion3();
                        Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 4:
                        Opcion4();
                        Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 0:
                        opcion = 0;
                        break;
                }
            }
            while (opcion != 0);
        }
    static public void Menu(string[] opciones)
    {
        Console.Clear();
        int numero = 1;
        Console.WriteLine("Ingresa una de las siguientes opciones (0 para finalizar)");
        foreach (string opcion in opciones)
        {
            Console.WriteLine(numero + " - " + opcion);
            numero++;
        }
    }

        static public void Opcion1()
        {
            List<Cliente> lista = unS.ObtenerClientes();

            foreach (Cliente unCliente in lista)
            {
                Console.WriteLine(unCliente.DatosClientes());
            }
        }

        static public void Opcion2()
        {
            Console.WriteLine("Ingrese código IATA del aeropuerto: ");
            string codigo = Console.ReadLine().ToUpper();

            List<Vuelo> vuelos = unS.VuelosPorAeropuerto(codigo);

            if (vuelos.Count == 0)
            {
                Console.WriteLine("No se encontraron vuelos para ese aeropuerto.");
                return;
            }

            foreach (Vuelo unVuelo in vuelos)
            {
                Console.WriteLine(unVuelo); 
            }
        }

        static public void Opcion3()
        {
            Console.Clear();
            Console.WriteLine("=== Alta de Cliente Ocasional ===");

            //como los valores se levantan antes de usar el metodo de alta que contiene el metodo Validar
            //los campos vacios no se validan hasta que el usuario ingreso todos los valores
            //no pude solucionarlo, para que se valide al momento que da enter con un campo vacio
            string correo = Utils.PedirTexto("Correo:");
            string contraseña = Utils.PedirTexto("Contraseña:");
            string documento = Utils.PedirTexto("Documento:");
            string nombre = Utils.PedirTexto("Nombre:");
            string nacionalidad = Utils.PedirTexto("Nacionalidad:");

            try
                { 
                unS.AltaClienteOcasional(correo, contraseña, documento, nombre, nacionalidad);
                }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        static public void Opcion4()
        {
            DateTime inicio = Utils.PedirFecha("Ingrese la fecha de inicio (mm/dd/yyyy): ");
            DateTime final = Utils.PedirFecha("Ingrese la fecha final (mm/dd/yyyy): ");

            List<Pasaje> lista = unS.PasajesEntreFechas(inicio, final);

            foreach(Pasaje unPasaje in lista)
            {
                Console.WriteLine($"\nID: {unPasaje.Id}\nPasajero: {unPasaje.Pasajero.Nombre}\nPrecio: {unPasaje.Precio}\nFecha: {unPasaje.Fecha}\nVuelo: {unPasaje.Vuelo.NumeroVuelo}");

            } 

        }
    }

}
