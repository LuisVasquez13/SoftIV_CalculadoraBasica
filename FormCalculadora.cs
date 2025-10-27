using System;
using System.Windows.Forms;

namespace SoftIV_CalculadoraBasica
{
    public partial class FormCalculadora : Form
    {
        // Variables para almacenar los operandos y la operación seleccionada
        double valor1 = 0;       // Primer número ingresado
        double valor2 = 0;       // Segundo número ingresado
        string operacion = "";   // Operación seleccionada (+, −, ×, ÷)
        bool nuevaOperacion = false; // Indica si se debe iniciar un nuevo número en el display

        public FormCalculadora()
        {
            InitializeComponent(); // Inicializa los controles del Form
            AsociarEventos();     // Asocia los eventos a los botones
        }

        // Método para asociar los eventos Click de los botones
        private void AsociarEventos()
        {
            // Botones numéricos y el punto decimal
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

            // Botón para borrar el último carácter
            btnBack.Click += BtnBack_Click;

            // Botones de operaciones
            btnSuma.Click += BotonOperacion_Click;
            btnResta.Click += BotonOperacion_Click;
            btnMultiplica.Click += BotonOperacion_Click;
            btnDivide.Click += BotonOperacion_Click;

            // Botón para calcular el resultado
            btnIgual.Click += BtnIgual_Click;

            // Botón para limpiar todo
            btnClear.Click += BtnClear_Click;
        }

        // Evento para manejar la entrada de números y el punto decimal
        private void BotonNumero_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender; // Botón que se presionó

            // Si el display está en 0 o es una nueva operación, limpia el display
            if (txtDisplay.Text == "0" || nuevaOperacion)
            {
                txtDisplay.Text = "";
                nuevaOperacion = false;
            }

            // Evita ingresar más de un punto decimal
            if (btn.Text == "." && txtDisplay.Text.Contains("."))
                return;

            // Agrega el número o el punto al display
            txtDisplay.Text += btn.Text;
        }

        // Evento para manejar la selección de operación (+, −, ×, ÷)
        private void BotonOperacion_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;           // Botón de operación presionado
            valor1 = double.Parse(txtDisplay.Text); // Guardar el primer operando
            operacion = btn.Text;                   // Guardar la operación
            nuevaOperacion = true;                  // Preparar para ingresar el segundo número
        }

        // Evento para calcular el resultado al presionar "="
        private void BtnIgual_Click(object sender, EventArgs e)
        {
            valor2 = double.Parse(txtDisplay.Text); // Obtener el segundo operando
            double resultado = 0;                    // Variable para almacenar el resultado

            // Aplicar la operación seleccionada
            switch (operacion)
            {
                case "+": resultado = valor1 + valor2; break;
                case "−": resultado = valor1 - valor2; break;
                case "×": resultado = valor1 * valor2; break;
                case "÷":
                    if (valor2 != 0)                 // Evitar división entre cero
                        resultado = valor1 / valor2;
                    else
                    {
                        MessageBox.Show("No se puede dividir entre cero."); // Mostrar error
                        return;                        // Salir sin cambiar el display
                    }
                    break;
            }

            // Mostrar resultado en el display
            txtDisplay.Text = resultado.ToString();
            nuevaOperacion = true; // Preparar el display para nueva entrada
        }

        // Evento para limpiar todo al presionar "C"
        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0"; // Reset del display
            valor1 = 0;             // Reset del primer operando
            valor2 = 0;             // Reset del segundo operando
            operacion = "";         // Reset de la operación
            nuevaOperacion = false; // Reset del estado
        }

        // Evento para borrar el último carácter del display al presionar "←"
        private void BtnBack_Click(object sender, EventArgs e)
        {
            string texto = txtDisplay.Text;

            // Para el display 0
            if (texto == "0")
                return;

            // Borra un solo carácter
            if (texto.Length > 1)
                txtDisplay.Text = texto.Substring(0, texto.Length - 1);
            else
                txtDisplay.Text = "0"; // Si queda vacío, mostrar 0
        }

        // Este evento para manejar cambios automáticos en el display
        private void txtDisplay_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
