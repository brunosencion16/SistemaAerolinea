using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Aeropuerto
    {
        private string codigoIATA;
        private string ciudad;
        private int costoOperacion;
        private int costoTasas;

        public string CodigoIATA { get => codigoIATA; set => codigoIATA = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public int CostoOperacion { get => costoOperacion; set => costoOperacion = value; }
        public int CostoTasas { get => costoTasas; set => costoTasas = value; }
        
        #region Constructores
        public Aeropuerto(string codigoIATA, string ciudad, int costoOperacion, int costoTasas)
        {
            CodigoIATA = codigoIATA;
            Ciudad = ciudad;
            CostoOperacion = costoOperacion;
            CostoTasas = costoTasas;
        }
        public Aeropuerto()
        {
        }
        #endregion

        #region Validaciones
        public void Validar()
        {
            ValidarCodigoIATA();
            ValidarCiudad();
            ValidarCostoOperacion();
            ValidarCostoTasas();
        }

        public void ValidarCodigoIATA()
        {
            if (string.IsNullOrEmpty(CodigoIATA) || codigoIATA.Length != 3) throw new Exception("El codigo IATA no puede ser vacio");
        }

        public void ValidarCiudad()
        {
            if (string.IsNullOrEmpty(Ciudad)) throw new Exception("La ciudad no puede ser vacio");
        }

        public void ValidarCostoOperacion()
        {
            if (CostoOperacion <= 0) throw new Exception("El costo de operacion no puede ser igual o menor a cero");
        }

        public void ValidarCostoTasas()
        {
            if (CostoTasas <= 0) throw new Exception("El costo de las tasas no puede ser igual o menor a cero");
        }
        #endregion

        public override string ToString()
        {
            return $"Codigo IATA:\t {CodigoIATA} Ciudad:\t {ciudad} Costo operacion:\t {costoOperacion} Costo tasas:\t {costoTasas}";
        }
        public override bool Equals(object? obj)
        {
            return (obj is Aeropuerto unAeropuerto && unAeropuerto.CodigoIATA == CodigoIATA);
        }

        
    }
}
