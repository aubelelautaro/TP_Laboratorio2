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
        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public ENacionalidad Nacionalidad { get; set; }

        public int DNI { get; set; }
        public string StringToDNI { set; }
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
            return $"asd";
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
