using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pasaje: IComparable
    {
        //ENUM
        public enum TipoEquipaje { light = 1, cabina = 2, bodega = 3};
        //ENUM
        public enum OrdenListado { precio, fecha};
        private static OrdenListado ordenarPor;

        private TipoEquipaje equipaje;
        private int id;
        private static int ultimoId;
        private Vuelo vuelo;
        private DateTime fecha;
        private Cliente pasajero;
        private decimal precio;

        public TipoEquipaje Equipaje { get => equipaje; set => equipaje = value; }
        public int Id { get => id; set => id = value; }
        public Vuelo Vuelo { get => vuelo; set => vuelo = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public Cliente Pasajero { get => pasajero; set => pasajero = value; }
        public decimal Precio { get => precio; set => precio = value; }

        #region Constructores
        public Pasaje(TipoEquipaje equipaje, Vuelo vuelo, DateTime fecha, Cliente pasajero, decimal precio)
        {
            Equipaje = equipaje;
            Id = ++ultimoId;
            Vuelo = vuelo;
            Fecha = fecha;
            Pasajero = pasajero;
            Precio = precio;
        }
        public Pasaje()
        {
        }
        #endregion
        #region Validaciones
        public void Validar()
        {
            ValidarPrecio();
            ValidarFrecuencia();
        }
        public void ValidarPrecio()
        {
            if (Precio <= 0) throw new Exception("El precio no puede ser igual o menor a cero");
        }

        public void ValidarFrecuencia()
        {
            if (!Vuelo.Frecuencia.Contains(Fecha.DayOfWeek)) throw new Exception("La fecha seleccionada no corresponde a la frecuencia del vuelo");
        }
        #endregion

        //calculo el costo por asiento o el "costo base"
        public decimal CalcularCostoBase()
        {
            decimal costoBase = (vuelo.Avion.CostoOperacion * vuelo.Ruta.Distancia + vuelo.Ruta.AeropuertoSalida.CostoOperacion + vuelo.Ruta.AeropuertoLlegada.CostoOperacion)/vuelo.Avion.CantAsientos;
            return costoBase;
        }

        //al costo base le agrego el margen de ganancia de la aerolinea que es un 25%
        public decimal CalcularGanancia(decimal costoBase)
        {
            decimal ganancia = costoBase * 0.25m;
            return ganancia;
        }

        public static void OrdenarPorPrecio()
        {
            ordenarPor = OrdenListado.precio;
        }

        public static void OrdenarPorFecha()
        {
            ordenarPor = OrdenListado.fecha;
        }
        public int CompareTo(Object obj)
        {
            Pasaje unP = obj as Pasaje;
            if(ordenarPor == OrdenListado.precio)
            {
                return - precio.CompareTo(unP.precio);
            }
            if(ordenarPor == OrdenListado.fecha)
            {
                return fecha.CompareTo(unP.fecha);
            }
            return 0;
        }
    }

}
