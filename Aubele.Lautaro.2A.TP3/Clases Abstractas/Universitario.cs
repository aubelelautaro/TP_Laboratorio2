using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        #region Constructores

        public Universitario()
        {

        }

        public Universitario(int legajo, string nombre, string apellido,string dni,ENacionalidad nacionalidad)
        {

        }

        #endregion


        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Se le agrega el legajo a la Persona
        /// </summary>
        /// <returns>Universitario con legajo</returns>
        protected virtual string MostrarDatos()
        {
            return base.ToString() + $"\nLEGAJO NÚMERO: {this.legajo}\n";
        }

        protected abstract string ParticiparEnClase();

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;
            if(pg1.Equals(pg2) && (pg1.legajo == pg2.legajo ||pg1.DNI == pg2.DNI))
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Universitario pg1,Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}
