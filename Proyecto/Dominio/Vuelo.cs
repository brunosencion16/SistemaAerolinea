using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Vuelo
    {

        private string numeroVuelo;
        private Ruta ruta;
        private Avion avion;
        private List<DayOfWeek> frecuencia = new List<DayOfWeek>();

        public string NumeroVuelo { get => numeroVuelo; set => numeroVuelo = value; }
        public Ruta Ruta { get => ruta; set => ruta = value; }
        public Avion Avion { get => avion; set => avion = value; }
        public List<DayOfWeek> Frecuencia { get => frecuencia; set => frecuencia = value; }
        #region Constructores

        public Vuelo(string numeroVuelo, Ruta ruta, Avion avion, List<DayOfWeek> frecuencia1)
        {
            NumeroVuelo = numeroVuelo;
            Ruta = ruta;
            Avion = avion;
            Frecuencia = frecuencia1;
        }

        public Vuelo()
        {

        }
        #endregion

        #region Validaciones
        public void Validar()
        {
            ValidarNumVuelo();
        }

        private void ValidarNumVuelo()
        {
            if (string.IsNullOrEmpty(NumeroVuelo)) throw new Exception("El numero de vuelo no puede ser vacio");
        }
        #endregion

        public override string ToString()
        {
            string diasFrecuencia = string.Join(", ", Frecuencia);
            return $"Vuelo: {NumeroVuelo} \nAvion: {Avion.Modelo} \nRuta: {Ruta} \nFrecuencia: {diasFrecuencia}";
        }

      
    }

    
}
