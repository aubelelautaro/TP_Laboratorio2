using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Entidades
{
    public static class PaqueteDAO
    {
        /// <summary>
        /// Atributos
        /// </summary>
        private static SqlCommand comando;
        private static SqlConnection conexion;

        #region Constructor
        static PaqueteDAO()
        {
            PaqueteDAO.conexion = new SqlConnection(Properties.Settings.Default.Conexion);
            PaqueteDAO.comando = new SqlCommand();
            PaqueteDAO.comando.Connection = conexion;
        }
        #endregion

        #region Metodo
        /// <summary>
        /// Ingresa un paquete a la base de datos
        /// </summary>
        /// <param name="p"></param>
        /// <returns>True si pudo escribir, sino false</returns>

        public static bool Insertar(Paquete p)
        {
            bool retorno = false;
            try
            {
                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection = conexion;
                comando.CommandText = string.Format("INSERT INTO Paquetes ([direccionEntrega], [trackingID], [alumno]) values ('{0}','{1}','Aubele Lautaro')", p.DireccionEntrega, p.TrackingID);
                //comando.CommandText = "INSERT INTO [correo-sp-2017].[dbo].[Paquetes] (direccionEntrega, trackingID, alumno) values ('{p.direccionEntrega}','{p.trackingID}', 'Aubele Lautaro')";

                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
                retorno = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error en la base de datos");
                throw e;
            }
 
            return retorno;
        }
        #endregion
    }
}
