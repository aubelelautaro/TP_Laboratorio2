using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Constructores

        public Profesor()
        {

        }
        static Profesor()
        {
            random = new Random();
        }

        public Profesor(int id,string nombre,string apellido, string dni, Persona.ENacionalidad nacionalidad):base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        #region Metodo

        /// <summary>
        /// Devuelve 2 clases random al profesor
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 4));
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 4));
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga de participar en clase
        /// </summary>
        /// <returns>Las clases del dia en string</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DÍA:");

            foreach (Universidad.EClases clases in this.clasesDelDia)
            {
                sb.AppendLine(clases.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga de los datos en string
        /// </summary>
        /// <returns>Datos del universitario con las clases</returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + this.ParticiparEnClase();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>true si la clase del dia del profesor es igual a la clase pasada por parametro</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;

            foreach (Universidad.EClases clases in i.clasesDelDia)
            {
                if (clases == clase)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
