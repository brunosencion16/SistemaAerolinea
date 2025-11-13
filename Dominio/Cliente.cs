using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Cliente : Usuario, IComparable
    {
        private string documento;
        private string nombre;
        private string nacionalidad;

        public string Documento { get => documento; set => documento = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Nacionalidad { get => nacionalidad; set => nacionalidad = value; }

        #region Constructores
        public Cliente()
        {
        }
        public Cliente(string correo, string contraseña, string documento, string nombre, string nacionalidad)
            : base(correo, contraseña)
        {
            Documento = documento;
            Nombre = nombre;
            Nacionalidad = nacionalidad;
        }
        #endregion

        #region Validaciones
        public void Validar()
        {
            ValidarDocumento();
            ValidarNombre();
            ValidarNacionalidad();
            ValidarCorreo();
            ValidarContraseña();
        }

        public void ValidarDocumento()
        {
            if (string.IsNullOrEmpty(Documento)) throw new Exception("El documento no puede estar vacio");
        }

        public void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre)) throw new Exception("El nombre no puede estar vacio");
        }

        public void ValidarNacionalidad()
        {
            if (string.IsNullOrEmpty(Nacionalidad)) throw new Exception("La nacionalidad no puede estar vacio");
        }

        #endregion

        public override string ToString()
        {
            return $"{base.ToString()}Documento: {documento} \nNombre: {nombre}  \nNacionalidad: {nacionalidad}";
        }


        public virtual string DatosClientes()
        {
            return $"\nNombre: {Nombre} \nEmail: {Correo} \nNacionalidad: {Nacionalidad}";
        }

        public abstract decimal CalcularRecargoEquipaje(Pasaje.TipoEquipaje equipaje, decimal precioParcial);
    

        public int CompareTo(Object obj)
        {
            Cliente unC = obj as Cliente;
            return documento.CompareTo(unC);
        }
    }
}
