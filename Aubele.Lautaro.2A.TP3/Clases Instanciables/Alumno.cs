using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #region Constructores

        public Alumno()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
        {
            this.DNI = id;
            this.Nombre = nombre;
            this.Nacionalidad = nacionalidad;
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta):this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        protected override string MostrarDatos()
        {
            return base.ToString() + $"\nESTADO DE CUENTA: {this.estadoCuenta}\n" + this.ParticiparEnClase();
        }

        protected override string ParticiparEnClase()
        {
            return $"TOMA CLASES DE {this.claseQueToma}";
        }

        #region Sobrecargas

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;
            if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;
            if(a.claseQueToma != clase)
            {
                retorno = true;
            }
            return retorno;
        }

        public override string ToString()
        {
            return this.MostrarDatos();
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
