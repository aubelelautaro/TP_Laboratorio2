using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
		/// Guarda datos en txt de un paquete en el escritorio
		/// </summary>
		/// <param name="texto"></param>
		/// <param name="archivo"></param>
		/// <returns>True si lo pudo guardar, sino false</returns>
		public static bool Guardar(this string texto, string archivo)
        {
            StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo, true);

            bool retorno = false;
            try
            {
                sw.Write(texto);
                sw.Close();
                retorno = true;
            }
            catch (Exception e)
            {
                throw e;
            }

            return retorno;
        }
    }
}
