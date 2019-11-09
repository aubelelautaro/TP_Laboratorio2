using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda archivos en xml
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>True si pudo guardar el archivo</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                XmlTextWriter tw = new XmlTextWriter(archivo, Encoding.UTF8);
                serializer.Serialize(tw, datos);

                tw.Close();
                retorno = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }

        /// <summary>
        /// Lee archivos xml
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>True si pudo leer el archivo</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                XmlTextReader lectura = new XmlTextReader(archivo);

                datos = (T)serializer.Deserialize(lectura);

                lectura.Close();

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
