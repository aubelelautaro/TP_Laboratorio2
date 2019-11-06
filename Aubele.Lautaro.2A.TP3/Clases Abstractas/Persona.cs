using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    
    public abstract class Persona
    {
        #region Campos
        private string apellido;
        private string nombre;
        private ENacionalidad nacionalidad;
        private int dni;
        #endregion

        #region Propiedades

        public string Apellido
        {
            get
            {
              return this.apellido;
            }
            set
            {
              this.apellido = ValidarNombreApellido(value);
            }
        }

        public string Nombre
        {
            get
            {
              return this.nombre;
            }
            set
            {
              this.nombre = ValidarNombreApellido(value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
              return this.nacionalidad;
            }
            set
            {
              this.nacionalidad = value;
            }
        }

        public int DNI
        {
            get
            {
              return this.dni;
            }
            set
            {
              this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }
    #endregion

        #region Constructores
        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre,apellido,dni.ToString(),nacionalidad)
        {

        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return $"NOMBRE COMPLETO: {this.apellido}, {this.nombre}\n NACIONALIDAD: {this.nacionalidad}\n";
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if(this.nacionalidad == ENacionalidad.Argentino && (dato >=1 || dato <=89999999))
            {
                return dato;
            }else if(this.nacionalidad == ENacionalidad.Extranjero &&(dato>= 90000000 && dato<=99999999))
            {
                return dato;
            }
            else if(dato>99999999 || dato<1)
            {
                throw new DniInvalidoException();
            }
            else
            {
                throw new NacionalidadInvalidaException();
            }
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni = 0;

            try
            {
                dni = int.Parse(dato);
            }
            catch (Exception)
            {
                throw new DniInvalidoException();
            }

            return ValidarDni(nacionalidad, dni);
        }

        private string ValidarNombreApellido(string dato)
        {
            foreach (char letra in dato)
            {
                if (!char.IsLetter(letra))
                {
                    throw new Exception("Ingrese solo letras");

                }
            }
            return dato;
        }
        #endregion

        #region Enumerados
        /// <summary>
        /// Enumerado de Nacionalidad
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion
    }
}
