using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #region Propiedades
        public List<Alumno> Alumnos { get; set; }

        public List<Jornada> Jornadas { get; set; }

        public List<Profesor> Instructores { get; set; }

        public Jornada this[int i] { get; set; }
        #endregion


        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        public bool Guardar(Universidad uni)
        {
            return false;
        }

        public Universidad Leer()
        {
            return "as";
        }

        private string MostrarDatos(Universidad uni)
        {
            return "a";
        }
        #region Sobrecargas
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        public static bool operator ==(Universidad g, Alumno a)
        {

        }
        public static bool operator ==(Universidad g, Profesor i)
        {

        }

        public static Profesor operator ==(Universidad u, EClases clase)
        {

        }

        public static Profesor operator !=(Universidad u, EClases clase)
        {
            return !(g == i);
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
            return base.ToString();
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
