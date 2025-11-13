using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Premium:Cliente
    {
        private int puntos;


        public int Puntos { get => puntos; set => puntos = value; }

        #region Constructores
        public Premium(string correo, string contraseña, string documento, string nombre, string nacionalidad, int puntos)
            :base(correo, contraseña, documento, nombre, nacionalidad)
        {
            Puntos = puntos;
        }
        public Premium()
        {
        }
        #endregion

        public override string ToString()
        {
            return $"{base.ToString()} Regalos de cabina:\t {puntos.ToString()}";
        }

        public override string DatosClientes()
        {
            return $"{base.DatosClientes()} Puntos:\t {Puntos}";
        }

        public override decimal CalcularRecargoEquipaje(Pasaje.TipoEquipaje equipaje, decimal precioParcial)
        {
            if(equipaje == Pasaje.TipoEquipaje.bodega)
            {
                return precioParcial * 0.05m;
            }
            else
            {
                return precioParcial;
            }
        }
    }
}
