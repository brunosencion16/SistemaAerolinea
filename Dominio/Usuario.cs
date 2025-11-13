using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        private string correo;
        private string contraseña;

        public string Correo { get => correo; set => correo = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }

        public Usuario(string correo, string contraseña)
        {
            Correo = correo;
            Contraseña = contraseña;
        }
        public Usuario()
        {
        }
        #region Validaciones
        public void Validar()
        {
            ValidarCorreo();
            ValidarContraseña();
        }
        public void ValidarCorreo()
        {
            if (string.IsNullOrEmpty(Correo)) throw new Exception("El correo no puede estar vacio");
        }

        public void ValidarContraseña()
        {
            if (string.IsNullOrEmpty(Contraseña)) throw new Exception("La contraseña no puede estar vacio");
        }
#endregion

        public override string ToString()
        {
            return $"Correo:\t {Correo}";
        }

        public override bool Equals(object? obj)
        {
            return (obj is Usuario unUsuario && unUsuario.Correo == Correo);
        }
    }
}
