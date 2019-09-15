using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase con la lógica parar operar con los numeros
    /// </summary>
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Setea el valor validado a numero
        /// </summary>
        private string SetNumero { set { numero = ValidarNumero(value); } }
        /// <summary>
        /// Metodo que convierte un binario a decimal
        /// </summary>
        /// <param name="binario">Binario en string</param>
        /// <returns>Numero convertido a decimal o "Valor inválido"</returns>
        public static string BinarioDecimal(string binario)
        {
            int[] cadena = new int[binario.Length];
            string retorno = "";
            bool flag = true;
            double num = 0;
            int i;
            for (i = 0; i < binario.Length; i++)
            {
                cadena[i] = (int)char.GetNumericValue(binario[i]);
                if (cadena[i] != 0 && cadena[i] != 1)
                {
                    flag = false;
                    break;
                }
            }
            if (flag == true)
            {
                for (i = 0; i < binario.Length; i++)
                {
                    num += (cadena[i] * Math.Pow(2, binario.Length - i - 1));
                }
                retorno = num.ToString();
            }
            else
            {
                retorno = "Valor inválido";
            }

            return retorno;
        }

        /// <summary>
        /// Convierte un decimal a binario
        /// </summary>
        /// <param name="numero">Double a convertir</param>
        /// <returns>Numero convertido a binario en string</returns>
        public static string DecimalBinario(double numero)
        {
            int num = (int)numero;
            string binario = "";
            while (numero > 0)
            {
                if(numero % 2 == 0)
                {
                    binario += "0";
                }else
                {
                    binario += "1";
                }
                numero = (int)numero / 2;
            }
            if(numero == 0)
            {
                binario = "0";
            }
            char[] ArrayBin = binario.ToCharArray();
            Array.Reverse(ArrayBin);
            return new string(ArrayBin);
        }

        /// <summary>
        /// Sobrecarga que valida que la cadena sea correcta y la convierte de decimal a binario
        /// </summary>
        /// <param name="numero">Numero decimal en string</param>
        /// <returns>Decimal convertido a binario o "Valor inválido"</returns>
        public static string DecimalBinario(string numero)
        {
            double num;
            string retorno = "Valor inválido";
            if (double.TryParse(numero, out num))
            {
                retorno = DecimalBinario(num);
            }

            return retorno;
        }

        /// <summary>
        /// Constructor que inicializa a un objeto Numero en 0
        /// </summary>
        public Numero() : this(0)
        {
        }

        /// <summary>
        /// Constructor que inicializa al objeto Numero con el valor por parametro
        /// </summary>
        /// <param name="numero">Valor que se le pasa al objeto Numero</param>
        public Numero(double numero) : this(numero.ToString())
        {
        }

        /// <summary>
        /// Constructor que inicializa al objeto numero con el parametro string
        /// </summary>
        /// <param name="strNumero">Valor que se le setea al objeto Numero</param>
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        /// <summary>
        /// Metodo para validar que el parametro pasado se puede parsear a un double
        /// </summary>
        /// <param name="strNumero">Numero en string</param>
        /// <returns>El valor parseado o 0 si no se pudo parsear</returns>
        private double ValidarNumero(string strNumero)
        {
            double num;
            double.TryParse(strNumero, out num);
            return num;
        }

        /// <summary>
        /// Sobrecarga de la resta
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>Resultado de la operacion</returns>
        public static double operator -(Numero num1, Numero num2)
        {
            return num1.numero - num2.numero;
        }

        /// <summary>
        /// Sobrecarga de la suma
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>Resultado de la operacion</returns>
        public static double operator +(Numero num1, Numero num2)
        {
            return num1.numero + num2.numero;
        }

        /// <summary>
        /// Sobrecarga de la division
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>Resultado de la operacion</returns>
        public static double operator /(Numero num1, Numero num2)
        {
            if (num2.numero != 0)
            {
                return num1.numero / num2.numero;
            }
            else
            {
                return double.MinValue;
            }
        }

        /// <summary>
        /// Sobrecarga de la multipliacion
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>Resultado de la operacion</returns>
        public static double operator *(Numero num1, Numero num2)
        {
            return num1.numero * num2.numero;
        }
    }
}
