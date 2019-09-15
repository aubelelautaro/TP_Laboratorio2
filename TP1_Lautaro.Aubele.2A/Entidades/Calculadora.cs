using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase que realizará operaciones entre datos de tipo Numero
    /// </summary>
    public static class Calculadora
    {
        /// <summary>
        /// Metodo que opera segun el operador indicado
        /// </summary>
        /// <param name="num1">Primer numero</param>
        /// <param name="num2">Segundo numero</param>
        /// <param name="operador">(+,-,/,*)</param>
        /// <returns>Retorna un double con el resultado</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = 0;
            switch (ValidarOperador(operador))
            {
                case "+":
                    retorno = num1 + num2;
                    break;
                case "-":
                    retorno = num1 - num2;
                    break;
                case "*":
                    retorno = num1 * num2;
                    break;
                case "/":
                    retorno = num1 / num2;
                    break;
            }
            return retorno;
        }

        /// <summary>
        /// Valida que el operador sea alguno de los 4 operadores (+,-,*,/)
        /// </summary>
        /// <param name="operador">El operador el cual se va a validar</param>
        /// <returns>Retorna (+,-,*,/) o + si no es ninguno de los 4 operadores</returns>
        private static string ValidarOperador(string operador)
        {
            string retorno = "+";
            if (operador == "+" || operador == "-" || operador == "/" || operador == "*")
            {
                retorno = operador;
            }
            return retorno;
        }
    }
}
