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
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;


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
            this._randomClases();
            this.clasesDelDia = new Queue<Universidad.EClases>();
        }
        #endregion

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

        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 4));
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 4));
        }
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + this.ParticiparEnClase();
        }

        #region Sobrecargas

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
