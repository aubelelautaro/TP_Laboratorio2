using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda archivos en txt
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>True si pudo guardar el archivo</returns>
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;
            try
            {
                StreamWriter sw = new StreamWriter(archivo);

                sw.Write(datos);
                sw.Close();
                retorno = true;
            }
            catch (Exception e)
            {

                throw new ArchivosException(e);
            }

            return retorno;
        }

        /// <summary>
        /// Lee archivos en txt
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>True si pudo leer el archivo</returns>
        public bool Leer(string archivo,out string datos)
        {
            bool retorno = false;
            try
            {
                StreamReader sr = new StreamReader(archivo,true);

                datos = sr.ReadToEnd();
                sr.Close();

                retorno = true;
            }
            catch (Exception e)
            {

                throw new ArchivosException(e);
            }

            return retorno;
        }
    }
}
