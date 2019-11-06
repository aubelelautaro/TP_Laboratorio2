using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public class Jornada
    {
        #region Atributos

        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos { get; set; }

        public EClases Clase { get; set; }

        public Profesor Instructor { get; set; }

        #endregion

        public bool Guardar(Jornada jornada)
        {
            return false;
        }

        #region Constructor
        private Jornada()
        {

        }
        public Jornada(EClases clase, Profesor instructor)
        {

        }
        #endregion

        public string Leer()
        {
            return "as";
        }

        #region Sobrecargas
        public override string ToString()
        {
            return base.ToString(); 
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            return false;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            return j;
        }
        #endregion


    }
}
