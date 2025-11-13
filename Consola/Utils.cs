using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola
{
    internal class Utils
    {
        static public int PedirNumero(string mensaje = "Ingrese número.")
        {
            int numero;
            bool exito;
            do
            {
                Titulo(mensaje);
                exito = int.TryParse(Console.ReadLine(), out numero);
                if (!exito)
                {
                    MensajeError("Debe escribir solo numeros.");
                }
            } while (!exito);

            return numero;
        }

        static public void MensajeError(string mensaje)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"---Error---- {mensaje}");
            Console.BackgroundColor = ConsoleColor.Black;
        }

        static public void Titulo(string titulo)
        {
            Console.Write($"{titulo}: ");
        }

        public static string PedirTexto(string mensaje)
        {
            Titulo($"{mensaje} ");
            return Console.ReadLine().Trim();
        }

        //no logre que el formato de fecha quedara dd/mm/yyyy
        //actualmente en mi pc funciona como mm/dd/yyyy
        public static DateTime PedirFecha(string mensaje)
        {
            DateTime fecha;
            bool esValido;

            do
            {
                Console.Write($"{mensaje} ");
                string input = Console.ReadLine().Trim();
                esValido = DateTime.TryParse(input, out fecha);

                if (!esValido)
                {
                    MensajeError("Fecha inválida. Ingresá una fecha en formato válido.");
                }

            } while (!esValido);

            return fecha;
        }
    }
}
