using System;
using System.Windows.Forms;

namespace SoftIV_CalculadoraBasica
{
    public partial class FormCalculadora : Form
    {
        // Variables de operación
        private double valor1 = 0;
        private double valor2 = 0;
        private string operacion = "";
        private bool justPressedOperator = false; // indica si acaba de presionarse un operador

        public FormCalculadora()
        {
            InitializeComponent();
            AsociarEventos();
            txtDisplay.KeyPress += txtDisplay_KeyPress;
            txtDisplay.Text = "0";
        }

        private void AsociarEventos()
        {
            // Números y punto
            btn0.Click += BotonNumero_Click;
            btn1.Click += BotonNumero_Click;
            btn2.Click += BotonNumero_Click;
            btn3.Click += BotonNumero_Click;
            btn4.Click += BotonNumero_Click;
            btn5.Click += BotonNumero_Click;
            btn6.Click += BotonNumero_Click;
            btn7.Click += BotonNumero_Click;
            btn8.Click += BotonNumero_Click;
            btn9.Click += BotonNumero_Click;
            btnPunto.Click += BotonNumero_Click;

            // Operadores
            btnSuma.Click += BotonOperacion_Click;
            btnResta.Click += BotonOperacion_Click;
            btnMultiplica.Click += BotonOperacion_Click;
            btnDivide.Click += BotonOperacion_Click;

            // Funcionales
            btnIgual.Click += BtnIgual_Click;
            btnClear.Click += BtnClear_Click;
            btnBack.Click += BtnBack_Click;
        }

        // ============================
        // NÚMEROS Y PUNTO DECIMAL
        // ============================
        private void BotonNumero_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string tecla = btn.Text;

            if (justPressedOperator) // limpiar pantalla tras operador
            {
                txtDisplay.Text = "";
                justPressedOperator = false;
            }

            if (txtDisplay.Text.Length >= 12) // límite de dígitos
                return;

            if (tecla == "." && txtDisplay.Text.Contains(".")) // solo un punto decimal
                return;

            if (string.IsNullOrEmpty(txtDisplay.Text) || txtDisplay.Text == "0") // reemplazar cero inicial
            {
                txtDisplay.Text = (tecla == ".") ? "0." : tecla;
            }
            else // agregar dígito normal
            {
                txtDisplay.Text += tecla;
            }
        }

        // ============================
        // OPERADORES (+ - * /)
        // ============================
        private void BotonOperacion_Click(object sender, EventArgs e) 
        {
            Button btn = (Button)sender;
            string nuevaOp = btn.Text;

            if (justPressedOperator) // evitar doble operador
                return;

            if (!string.IsNullOrEmpty(operacion) && !justPressedOperator) // calcular si ya hay operación pendiente
            {
                if (double.TryParse(txtDisplay.Text, out double actual))
                {
                    valor2 = actual;
                    double resultado = CalcularOperacion(valor1, valor2, operacion);
                    txtDisplay.Text = resultado.ToString();
                    valor1 = resultado;
                }
            }
            else
            {
                double.TryParse(txtDisplay.Text, out valor1); // guardar primer valor
            }

            operacion = nuevaOp; // actualizar operación
            justPressedOperator = true; // indicar que se presionó un operador
        }

        // ============================
        // IGUAL (=)
        // ============================
        private void BtnIgual_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(operacion)) // nada que calcular
                return;

            if (!double.TryParse(txtDisplay.Text, out valor2)) // obtener segundo valor
                valor2 = 0;

            double resultado = CalcularOperacion(valor1, valor2, operacion); // calcular
            
            if (double.IsInfinity(resultado) || double.IsNaN(resultado)) 
            { 
                MessageBox.Show("Operación inválida (división por cero).");
                return;
            }

            txtDisplay.Text = resultado.ToString();
            valor1 = resultado;
            operacion = "";
        }

        // ============================
        // LIMPIAR (C)
        // ============================
        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            valor1 = valor2 = 0;
            operacion = "";
            justPressedOperator = false;
        }

        // ============================
        // RETROCESO (←)
        // ============================
        private void BtnBack_Click(object sender, EventArgs e)
        {
            string texto = txtDisplay.Text;
            if (string.IsNullOrEmpty(texto) || texto == "0") return;

            txtDisplay.Text = texto.Length <= 1 ? "0" : texto[..^1];
        }

        // ============================
        // CÁLCULO DE OPERACIONES
        // ============================
        private double CalcularOperacion(double a, double b, string op)
        {
            return op switch
            {
                "+" => a + b,
                "−" or "-" => a - b,
                "×" or "*" => a * b,
                "÷" or "/" => b == 0 ? double.NaN : a / b,
                _ => b
            };
        }

        // ============================================
        // TECLADO: DETECCIÓN DE TECLAS Y BLOQUEO TEXTO
        // ============================================
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Números (fila superior)
            if (keyData >= Keys.D0 && keyData <= Keys.D9)
            {
                BotonNumero_ClickVirtual(((int)(keyData - Keys.D0)).ToString());
                return true;
            }

            // Números (numpad)
            if (keyData >= Keys.NumPad0 && keyData <= Keys.NumPad9)
            {
                BotonNumero_ClickVirtual(((int)(keyData - Keys.NumPad0)).ToString());
                return true;
            }

            // Punto o coma decimal
            if (keyData == Keys.OemPeriod || keyData == Keys.Decimal || keyData == Keys.Oemcomma)
            {
                BotonNumero_ClickVirtual(".");
                return true;
            }

            // Operadores
            if (keyData == Keys.Add || (keyData == Keys.Oemplus && Control.ModifierKeys == Keys.Shift))
            {
                BotonOperacion_ClickVirtual("+");
                return true;
            }

            if (keyData == Keys.Subtract || keyData == Keys.OemMinus)
            {
                BotonOperacion_ClickVirtual("-");
                return true;
            }

            if (keyData == Keys.Multiply)
            {
                BotonOperacion_ClickVirtual("*");
                return true;
            }

            if (keyData == Keys.Divide || keyData == Keys.OemQuestion)
            {
                BotonOperacion_ClickVirtual("/");
                return true;
            }

            // Igual o Enter
            if (keyData == Keys.Enter || (keyData == Keys.Oemplus && Control.ModifierKeys == Keys.None))
            {
                BtnIgual_Click(null, null);
                return true;
            }

            // Borrar o limpiar
            if (keyData == Keys.Back)
            {
                BtnBack_Click(null, null);
                return true;
            }

            if (keyData == Keys.Delete || keyData == Keys.Escape)
            {
                BtnClear_Click(null, null);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        // Llamadas virtuales (para teclado)
        private void BotonNumero_ClickVirtual(string valor)
        {
            Button btn = new() { Text = valor };
            BotonNumero_Click(btn, EventArgs.Empty);
        }

        private void BotonOperacion_ClickVirtual(string oper)
        {
            Button btn = new() { Text = oper };
            BotonOperacion_Click(btn, EventArgs.Empty);
        }

        // Evita escribir directamente en el TextBox
        private void txtDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
