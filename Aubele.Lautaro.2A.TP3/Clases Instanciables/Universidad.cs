using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }

            set
            {
                this.alumnos = value;
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }

            set
            {
                this.jornada = value;
            }
        }

        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }

            set
            {
                this.profesores = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }

            set
            {
                this.jornada[i] = value;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor que inicializa las listas
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion

        public bool Guardar(Universidad uni)
        {
            return false;
        }

        public static Universidad Leer()
        {

            return ;
        }

        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada jornada in uni.jornada)
            {
                sb.AppendLine(jornada.ToString());
            }
            return sb.ToString();
        }
        #region Sobrecargas
        

        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno alumno in g.alumnos)
            {
                if (a == alumno)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;

            foreach (Profesor profesor in g.profesores)
            {
                if (i == profesor)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static Profesor operator ==(Universidad u, EClases clase)
        {

            foreach (Profesor profesor in u.profesores)
            {
                if (profesor == clase)
                {
                    return profesor;
                }
            }

            throw new SinProfesorException();
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Profesor operator !=(Universidad u, EClases clase)
        {
            return !(g == u);
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {

        }

        public static Universidad operator +(Universidad u, Alumno a)
        {
            
        }

        public static Universidad operator +(Universidad u, Profesor i)
        {

        }
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        #endregion

        #region Enumerados
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion
    }
}
