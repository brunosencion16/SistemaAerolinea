using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Ruta
    {
        private int id;
        private static int ultimoId;
        private Aeropuerto aeropuertoSalida;
        private Aeropuerto aeropuertoLlegada;
        private int distancia;

        public int Id { get => id; set => id = value; }
        public Aeropuerto AeropuertoSalida { get => aeropuertoSalida; set => aeropuertoSalida = value; }
        public Aeropuerto AeropuertoLlegada { get => aeropuertoLlegada; set => aeropuertoLlegada = value; }
        public int Distancia { get => distancia; set => distancia = value; }

        #region Constructores
        public Ruta(Aeropuerto aeropuertoSalida, Aeropuerto aeropuertoLlegada, int distancia)
        {
            //id autoincremental
            Id = ++ultimoId;
            AeropuertoSalida = aeropuertoSalida;
            AeropuertoLlegada = aeropuertoLlegada;
            Distancia = distancia;
        }
        public Ruta()
        {
        }
        #endregion

        public override string ToString()
        {
            return $"{AeropuertoSalida.CodigoIATA} - {AeropuertoLlegada.CodigoIATA} ({Distancia}km)";
        }

        
    }
}
