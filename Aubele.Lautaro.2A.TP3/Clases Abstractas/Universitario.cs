using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
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

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return base.Equals(obj);
        }
        protected string MostrarDatos()
        {
            return "aa";
        }

        protected string ParticiparEnClase()
        {
            return "asd";
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return false;
        }

        public static bool operator !=(Universitario pg1,Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}
