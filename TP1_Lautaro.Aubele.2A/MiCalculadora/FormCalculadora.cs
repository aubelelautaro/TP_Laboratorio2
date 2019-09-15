using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Constructor de la clase FormCalculadora
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
            string[] operadores = { "+", "-", "/", "*" };
            foreach(string operador in operadores)
            {
                this.cmbOperador.Items.Add(operador);
            }
            this.cmbOperador.SelectedIndex = 0;
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            if (!((txtNumero1.Text).All(char.IsDigit)) || txtNumero1.Text == "" || !((txtNumero2.Text).All(char.IsDigit)) || txtNumero2.Text == "")
            {
                txtNumero1.Text = "0";
                txtNumero2.Text = "0";
                lblResultado.Text = "0";
                btnConvertirABinario.Enabled = false;
                btnConvertirADecimal.Enabled = false;
            }
            else
            {
                lblResultado.Text = resultado.ToString();
                btnConvertirABinario.Enabled = true;
            }
            if (cmbOperador.Text != "+" && cmbOperador.Text != "-" && cmbOperador.Text != "*" && cmbOperador.Text != "/")
            {
                cmbOperador.Text = "+";
            }
            
        }

        /// <summary>
        /// LLama al metodo limpiar y limpia los campos
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Cierra la aplicación
        /// </summary>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Llama a la funcion para convertir de decimal a binario.
        /// </summary>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
            if (lblResultado.Text != "Valor invalido")
            {
                btnConvertirABinario.Enabled = false;
                btnConvertirADecimal.Enabled = true;
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
                lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
                btnConvertirABinario.Enabled = true;
                btnConvertirADecimal.Enabled = false;
        }

        /// <summary>
        /// Limpia todos los campos,deshabilita que se pueda convertir y pone el resultado en 0
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.Text = String.Empty;
            lblResultado.Text = "0";
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }

        /// <summary>
        /// Realiza las operaciones llamando a operar de la clase Calculadora
        /// </summary>
        /// <param name="numero1">Primer numero</param>
        /// <param name="numero2">Segundo numero</param>
        /// <param name="operador"> Operador aritmetico</param>
        /// <returns>Resultado de la operación</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            return Calculadora.Operar(num1, num2, operador);
        }
    }
}
