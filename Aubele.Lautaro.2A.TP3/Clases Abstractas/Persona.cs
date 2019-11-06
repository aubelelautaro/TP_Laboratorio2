using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    
    public abstract class Persona
    {
        #region Campos
        private string apellido;
        private string nombre;
        private ENacionalidad nacionalidad;
        private int dni;
        #endregion

        #region Propiedades
        public string Apellido
        {
            get
            {
              return this.apellido;
            }
            set
            {
              this.apellido = value;
            }
        }

        public string Nombre
        {
            get
            {
              return this.nombre;
            }
            set
            {
              this.nombre = value;
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
              return this.nacionalidad;
            }
            set
            {
              this.nacionalidad = value;
            }
        }

        public int DNI
        {
            get
            {
              return this.dni;
            }
            set
            {
              this.dni = value;
            }
        }

        public string StringToDNI
        {
            get
            {
              return this.dni.ToString();
            }
        }
    #endregion

        #region Constructores
        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {

        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
        {

        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {

        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return $"NOMBRE COMPLETO: {this.apellido}, {this.nombre}\n NACIONALIDAD: {this.nacionalidad}";
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            return 2;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            return 3;
        }

        private string ValidarNombreApellido(string dato)
        {
            return "asd";
        }
        #endregion

        #region Enumerados
        /// <summary>
        /// Enumerado de Nacionalidad
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion
    }
}
