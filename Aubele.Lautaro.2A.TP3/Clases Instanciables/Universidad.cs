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
        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion


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

        #region Metodos
        /// <summary>
        /// Guarda en xml una Universidad
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>True si pudo guardarse la universidad o false en caso contrario</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();

            return xml.Guardar("Universidad.xml",uni);
        }

        /// <summary>
        /// Lee en xml una universidad
        /// </summary>
        /// <returns>La universidad si pudo leer</returns>
        public static Universidad Leer()
        {
            Xml<Universidad> lectura = new Xml<Universidad>();

            Universidad universidad = new Universidad();

            lectura.Leer("Universidad.xml", out universidad);

            return universidad;
        }

        /// <summary>
        /// Muestra los datos completos de la jornada
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>Las jornadas de la universidad en string</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA: ");

            foreach (Jornada j in uni.jornada)
            {
                sb.AppendLine(j.ToString());
            }
            return sb.ToString();
        }

        #endregion


        #region Sobrecargas

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
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
            return g.profesores.Contains(i);
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

            foreach (Profesor profesor in u.profesores)
            {
                if (profesor  != clase)
               {
                    return profesor;
                }
             }

            return null;
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada auxJornada = new Jornada(clase, g == clase);
            foreach (Alumno alumno in g.alumnos)
            {
                if(alumno == clase)
                {
                    auxJornada.Alumnos.Add(alumno);
                }

            }

            g.jornada.Add(auxJornada);

            return g;
        }

        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(u != a)
            {
                u.alumnos.Add(a);
            }else{
                throw new AlumnoRepetidoException();

            }
            return u;
        }

        public static Universidad operator +(Universidad u, Profesor i)
        {

            if(u!=i)
            {
                u.profesores.Add(i);
            }

            return u;
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
