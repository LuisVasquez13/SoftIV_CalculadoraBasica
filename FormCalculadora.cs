using System;
using System.Windows.Forms;

namespace SoftIV_CalculadoraBasica
{
    public partial class FormCalculadora : Form
    {
        // Operandos y operación
        private double valor1 = 0;
        private double valor2 = 0;
        private string operacion = "";

        // Flags de control:
        // justPressedOperator: true justo después de presionar + - * /.
        // significa que el siguiente dígito debe comenzar el segundo operando (limpia el display una vez).
        private bool justPressedOperator = false;

        public FormCalculadora()
        {
            InitializeComponent();
            AsociarEventos();
            txtDisplay.KeyPress += txtDisplay_KeyPress;

            // Asegurar que el display comienza en "0"
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

            // Operaciones
            btnSuma.Click += BotonOperacion_Click;
            btnResta.Click += BotonOperacion_Click;
            btnMultiplica.Click += BotonOperacion_Click;
            btnDivide.Click += BotonOperacion_Click;

            // Funcionales
            btnIgual.Click += BtnIgual_Click;
            btnClear.Click += BtnClear_Click;
            btnBack.Click += BtnBack_Click;
        }

        /// <summary>
        /// Maneja los botones numéricos y el punto decimal.
        /// Comportamiento clave:
        /// - Si justPressedOperator == true => limpiar el display una sola vez y comenzar el segundo operando.
        /// - En cualquier otro caso, siempre concatenar el dígito/punto al contenido actual (no sobrescribir).
        /// - Permitir solo un punto decimal.
        /// - Si display es "0" y se presiona un dígito distinto de ".", reemplazar "0" por ese dígito.
        /// </summary>
        private void BotonNumero_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string tecla = btn.Text;

            // Si justo presionamos un operador, limpiar display SOLO UNA VEZ
            if (justPressedOperator)
            {
                txtDisplay.Text = "";           // limpiar para ingresar el segundo operando
                justPressedOperator = false;    // solo limpiar una vez
            }

            // 🔹 Límite de caracteres (máximo 12 en pantalla)
            if (txtDisplay.Text.Length >= 12)
                return;

            // Evitar más de un punto decimal
            if (tecla == "." && txtDisplay.Text.Contains("."))
                return;

            // Si el display está vacío (o era "0"), tratar el punto y dígitos
            if (string.IsNullOrEmpty(txtDisplay.Text) || txtDisplay.Text == "0")
            {
                if (tecla == ".")
                {
                    // Comenzar con "0."
                    txtDisplay.Text = "0.";
                }
                else
                {
                    // Reemplazar "0" o vacío con el dígito presionado
                    txtDisplay.Text = tecla;
                }
            }
            else
            {
                // Concatenar siempre — nunca sobrescribir
                txtDisplay.Text += tecla;
            }
        }

        /// <summary>
        /// Maneja la selección de operador.
        /// Comportamiento:
        /// - Si hay una operación previa pendiente y ya se ingresó el segundo operando, calcularla antes de setear la nueva operación (encadenado).
        /// - Guardar valor1 y marcar justPressedOperator = true para que el próximo dígito empiece el segundo operando.
        /// </summary>
        private void BotonOperacion_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string nuevaOp = btn.Text;

            // Evitar operaciones consecutivas sin número intermedio
            if (justPressedOperator)
                return;


            // Si ya había una operación seleccionada y el usuario no está justo después de un operador,
            // interpretamos que quiere encadenar (ej. 2 + 3 + -> calcular 2+3 y usar resultado).
            if (!string.IsNullOrEmpty(operacion) && !justPressedOperator)
            {
                // Intentar calcular la operación anterior
                if (double.TryParse(txtDisplay.Text, out double actual))
                {
                    valor2 = actual;
                    double resultado = CalcularOperacion(valor1, valor2, operacion);
                    txtDisplay.Text = resultado.ToString();
                    valor1 = resultado; // resultado pasa a ser el primer operando del siguiente cálculo
                }
            }
            else
            {
                // No había operación previa: tomar el número actual como valor1
                if (double.TryParse(txtDisplay.Text, out double v))
                    valor1 = v;
                else
                    valor1 = 0;
            }

            operacion = nuevaOp;
            justPressedOperator = true; // el próximo dígito comenzará el segundo operando (se limpia una vez en BotonNumero_Click)
        }

        /// <summary>
        /// Calcula resultado al presionar "=".
        /// Tras mostrar el resultado:
        /// - valor1 queda con el resultado (para poder encadenar)
        /// - operacion se limpia (ya no hay operación pendiente)
        /// - NO se marca un flag que borre el display al teclear un dígito: teclear dígitos seguirá concatenando al resultado.
        /// </summary>
        private void BtnIgual_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(operacion))
                return;

            if (!double.TryParse(txtDisplay.Text, out valor2))
                valor2 = 0;

            double resultado = CalcularOperacion(valor1, valor2, operacion);

            // Si división por cero, mostrar mensaje y no cambiar estado
            if (double.IsInfinity(resultado) || double.IsNaN(resultado))
            {
                MessageBox.Show("Operación inválida (división por cero u otro error).");
                return;
            }

            txtDisplay.Text = resultado.ToString();
            valor1 = resultado;   // permitir encadenar operaciones
            operacion = "";       // ya no hay operación pendiente
            // important: NO seteamos justPressedOperator = true aquí,
            // para que al teclear un dígito se concatene al resultado (como pediste).
        }

        /// <summary>
        /// Botón C: limpia todo
        /// </summary>
        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            valor1 = 0;
            valor2 = 0;
            operacion = "";
            justPressedOperator = false;
        }

        /// <summary>
        /// Botón <- : borra un carácter
        /// </summary>
        private void BtnBack_Click(object sender, EventArgs e)
        {
            string texto = txtDisplay.Text;

            if (string.IsNullOrEmpty(texto) || texto == "0")
                return;

            // Si queda vacío después de borrar, mostrar "0"
            if (texto.Length <= 1)
            {
                txtDisplay.Text = "0";
                return;
            }

            txtDisplay.Text = texto.Substring(0, texto.Length - 1);
        }

        /// <summary>
        /// Función auxiliar que realiza la operación
        /// </summary>
        private double CalcularOperacion(double a, double b, string op)
        {
            switch (op)
            {
                case "+": return a + b;
                case "−":
                case "-": return a - b;
                case "×":
                case "*": return a * b;
                case "÷":
                case "/":
                    if (b == 0) return double.NaN; // manejo de división por cero se hace fuera
                    return a / b;
                default: return b;
            }
        }

        // ============================================
        // 🔹 CONTROL DE TECLADO Y BLOQUEO DE ENTRADAS
        // ============================================

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // 🔹 Detectar teclas numéricas (fila superior y numpad)
            if (keyData >= Keys.D0 && keyData <= Keys.D9)
            {
                string numero = ((int)(keyData - Keys.D0)).ToString();
                BotonNumero_ClickVirtual(numero);
                return true;
            }
            else if (keyData >= Keys.NumPad0 && keyData <= Keys.NumPad9)
            {
                string numero = ((int)(keyData - Keys.NumPad0)).ToString();
                BotonNumero_ClickVirtual(numero);
                return true;
            }

            // 🔹 Punto decimal (en ambos teclados)
            if (keyData == Keys.OemPeriod || keyData == Keys.Decimal || keyData == Keys.Oemcomma)
            {
                BotonNumero_ClickVirtual(".");
                return true;
            }

            // 🔹 Operadores comunes (tanto numpad como teclado principal)
            if (keyData == Keys.Add || keyData == Keys.Oemplus && Control.ModifierKeys == Keys.Shift)
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

            // 🔹 Igual (= o Enter)
            if (keyData == Keys.Enter || (keyData == Keys.Oemplus && Control.ModifierKeys == Keys.None))
            {
                BtnIgual_Click(null, null);
                return true;
            }

            // 🔹 Retroceso y limpieza
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

            // Si no es ninguna tecla relevante, continuar con comportamiento normal
            return base.ProcessCmdKey(ref msg, keyData);
        }


        /// <summary>
        /// Llama al mismo método que los botones numéricos, pero desde teclado.
        /// </summary>
        private void BotonNumero_ClickVirtual(string valor)
        {
            Button btn = new Button();
            btn.Text = valor;
            BotonNumero_Click(btn, EventArgs.Empty);
        }

        /// <summary>
        /// Llama al mismo método que los botones de operador, pero desde teclado.
        /// </summary>
        private void BotonOperacion_ClickVirtual(string oper)
        {
            Button btn = new Button();
            btn.Text = oper;
            BotonOperacion_Click(btn, EventArgs.Empty);
        }

        /// <summary>
        /// Bloquea escritura manual directa en el TextBox.
        /// </summary>
        private void txtDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; // evita que se escriba directamente
        }
    }

}
