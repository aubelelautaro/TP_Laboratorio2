using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        #region Atributos
        
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
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

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }

            set
            {
                this.clase = value;
            }
        }
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }

            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region Constructor
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase, Profesor instructor):this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guarda en txt una jornada
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>True si pudo guardarse la jornada o false en caso contrario</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto txt = new Texto();

            return txt.Guardar("Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Lee en txt una jornada
        /// </summary>
        /// <returns>La jornada llena si pudo leer o un string vacio</returns>
        public static string Leer()
        {
            Texto lectura = new Texto();

            string j = "";

            lectura.Leer("Jornada.txt", out j);

            return j;
        }
        #endregion

        #region Sobrecargas

        /// <summary>
        /// Convierte a string toda la jornada
        /// </summary>
        /// <returns>La jornada completa en string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CLASE DE {this.clase} POR {this.instructor}\nALUMNOS:");
            foreach (Alumno alumno in this.alumnos)
            {
                sb.AppendLine(alumno.ToString());
            }
            sb.AppendLine("<------------------------------------------------------------->");
            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>true si el alumno esta en la jornada</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno alumno in j.alumnos)
            {
                if (alumno == a)
                {
                    retorno = true;
                }
            }
            

            return retorno;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un alumno a una jornada si no esta
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>Jornada con el alumno agregado</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j!=a)
            {
                j.alumnos.Add(a);
            }
            return j;
        }
        #endregion

    }
}
