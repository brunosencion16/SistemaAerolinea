using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Ocasional:Cliente
    {
        private bool regalosDeCabina;

        public bool RegalosDeCabina { get => regalosDeCabina; set => regalosDeCabina = value; }

        #region Constructores
        public Ocasional(string correo, string contraseña, string documento, string nombre, string nacionalidad, bool regalosDeCabina)
        : base(correo, contraseña, documento, nombre, nacionalidad)
        {
            RegalosDeCabina = regalosDeCabina;
        }
        public Ocasional()
        {
        }
        #endregion

        public override string ToString()
        {
            return $"{base.ToString()} Regalos de cabina: {regalosDeCabina}";
        }

        public override string DatosClientes()
        {
            string elegible;
            if (RegalosDeCabina) elegible = "Si";
            else elegible = "No";

            return $"{base.DatosClientes()} \nElegible: {elegible}";
        }

        public override bool Equals(object? obj)
        {
            return (obj is Ocasional unOcasional && unOcasional.Correo == Correo);
        }

        public override decimal CalcularRecargoEquipaje(Pasaje.TipoEquipaje equipaje, decimal precioParcial)
        {
            if(equipaje == Pasaje.TipoEquipaje.cabina)
            {
                return precioParcial * 0.10m;
            }
            else if(equipaje == Pasaje.TipoEquipaje.bodega)
            {
                return precioParcial * 0.20m;
            }
            else
            {
                return precioParcial;
            }
        }
    }
}
