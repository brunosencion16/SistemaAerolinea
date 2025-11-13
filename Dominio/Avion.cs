using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Avion
    {
        private string fabricante;
        private string modelo;
        private int cantAsientos;
        private int alcance;
        private int costoOperacion;

        public string Fabricante { get => fabricante; set => fabricante = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public int CantAsientos { get => cantAsientos; set => cantAsientos = value; }
        public int Alcance { get => alcance; set => alcance = value; }
        public int CostoOperacion { get => costoOperacion; set => costoOperacion = value; }
        
        #region Constructores
        public Avion(string fabricante, string modelo, int cantAsientos, int alcance, int costoOperacion)
        {
            Fabricante = fabricante;
            Modelo = modelo;
            CantAsientos = cantAsientos;
            Alcance = alcance;
            CostoOperacion = costoOperacion;
        }

        public Avion()
        {
        }
        #endregion

        #region Validaciones
        public void Validar()
        {
            ValiarFabricante();
            ValidarModelo();
            ValidarCantAsientos();
            ValidarAlcance();
            ValidarCostoOperacion();
        }

        public void ValiarFabricante()
        {
            if (string.IsNullOrEmpty(Fabricante)) throw new Exception("El fabricante no puede ser vacio");
        }

        public void ValidarModelo()
        {
            if (string.IsNullOrEmpty(Modelo)) throw new Exception("El modelo no puede ser vacio");
        }

        public void ValidarCantAsientos()
        {
            if (CantAsientos <= 0) throw new Exception("La cantidad de asientos no puede ser igual o menor a cero");
        }

        public void ValidarAlcance()
        {
            if (Alcance <= 0) throw new Exception("El costo de operacion no puede ser igual o menor a cero");
        }

        public void ValidarCostoOperacion()
        {
            if (CostoOperacion <= 0) throw new Exception("El costo de operacion no puede ser igual o menor a cero");
        }
        #endregion
    }
}
