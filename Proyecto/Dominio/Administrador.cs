using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Administrador:Usuario
    {
        private string apodo;


        public string Apodo { get => apodo; set => apodo = value; }

        #region Constructores
        public Administrador(string correo, string contraseña, string apodo)
            : base(correo, contraseña)
        {
            Apodo = apodo;
        }
        public Administrador()
        {
        }
        #endregion


        public override string ToString()
        {
            return $"{base.ToString()} Apodo:\t {apodo}";
        }

        #region Validaciones
        public void Validar()
        {
            ValidarApodo();
        }

        public void ValidarApodo()
        {
            if (string.IsNullOrEmpty(Apodo)) throw new Exception("El apodo no puede ser vacio");
        }
        #endregion
    }
}
