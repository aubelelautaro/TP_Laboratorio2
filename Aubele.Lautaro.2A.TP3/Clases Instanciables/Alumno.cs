using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    sealed class Alumno : Universitario
    {
        private EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #region Constructores

        public Alumno()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma)
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta)
        {

        }
        #endregion

        protected string MostrarDatos()
        {
            return "x";
        }

        protected string ParticiparEnClase()
        {
            return "x";
        }

        #region Sobrecargas

        public static bool operator ==(Alumno a, EClases clase)
        {

        }

        public static bool operator !=(Alumno a, EClases clase)
        {
            return !(a == clase);
        }

        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
        #region Enumerados
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion
    }
}
