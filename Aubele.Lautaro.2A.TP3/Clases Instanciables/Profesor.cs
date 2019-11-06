using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    sealed class Profesor
    {
        private Queue<EClases> clasesDelDia;
        private Random random;


        #region Constructores
        public Profesor()
        {

        }

        private Profesor()
        {

        }

        public Profesor(int id,string nombre,string apellido, string dni, ENacionalidad nacionalidad)
        {

        }
        #endregion

        protected string ParticiparEnClase()
        {
            return "as";
        } 

        private void _randomClases()
        {

        }
        protected string MostrarDatos()
        {
            return "asd";
        }

        #region Sobrecargas

        public static bool operator ==(Profesor i, EClases clase)
        {

        }

        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }

        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
}
