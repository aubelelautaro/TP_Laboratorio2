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

        public Universitario(int legajo, string nombre, string apellido,string dni,ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Se le agrega el legajo a la Persona
        /// </summary>
        /// <returns>Universitario con legajo</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"LEGAJO NÚMERO: {this.legajo}");
            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        #endregion

        #region Sobrecargas

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True si el objeto del parametro es igual al padre</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>True si son del mismo objeto los universitarios y si el legajo y el dni del universitario son iguales</returns>
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

        #endregion
    }
}
