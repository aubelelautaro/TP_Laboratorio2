using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IMostrar<T>
    {
        /// <summary>
        /// Metodo mostrando datos del elemento
        /// </summary>
        /// <param name="elemento">Elemento a mostrar</param>
        /// <returns>String con los datos</returns>
        string MostrarDatos(IMostrar<T> elemento);
    }
}
