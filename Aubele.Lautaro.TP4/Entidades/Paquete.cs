using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;

        /// <summary>
        /// Atributos
        /// </summary>
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        #region Propiedades

        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }

            set
            {
                this.direccionEntrega = value;
            }
        }

        public EEstado Estado
        {
            get
            {
                return this.estado;
            }

            set
            {
                this.estado = value;
            }
        }

        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }

            set
            {
                this.trackingID = value;
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de clase
        /// </summary>
        /// <param name="direccionEntrega">Direccion de entrega</param>
        /// <param name="trackingID">trackingID</param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Cambia el estado del paquete y agrega los datos de este en la base de datos
        /// </summary>
        public void MockCicloDeVida()
        {
            while (this.estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.Estado++;
                this.InformaEstado(this, null);
            }
            if (this.Estado == EEstado.Entregado)
            {
                try
                {
                    PaqueteDAO.Insertar(this);

                }
                catch (Exception exc)
                {
                    throw exc;
                }
            }
        }

        /// <summary>
        /// Sobreescribe la interfaz IMostrar, muestra los datos del paquete recibido
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>Datos del paquete en string</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = new Paquete(((Paquete)elemento).direccionEntrega, ((Paquete)elemento).trackingID);

            return string.Format("{0} para {1}\n", p.trackingID, p.direccionEntrega);
        }

        /// <summary>
        /// Llama a mostrar datos
        /// </summary>
        /// <returns>String con los datos del paquete</returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// p1 y p2 son iguales si tienen el mismo trackingID
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>True si son iguales, sino false</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool retorno = false;

            if (p1.trackingID == p2.trackingID)
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Negacion del == 
        /// </summary>
        /// <param name="p1">></param>
        /// <param name="p2">></param>
        /// <returns>True si son distintos,sino false</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion

        #region Enumerado
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
        #endregion
    }
}
