namespace SoftIV_CalculadoraBasica
{
    partial class FormCalculadora
    {
        /// <summary>
        ///  Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Limpiar los recursos que se estén utilizando.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            txtDisplay = new TextBox();
            lblTitulo = new Label();
            btn0 = new Button();
            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btn4 = new Button();
            btn5 = new Button();
            btn6 = new Button();
            btn7 = new Button();
            btn8 = new Button();
            btn9 = new Button();
            btnSuma = new Button();
            btnResta = new Button();
            btnMultiplica = new Button();
            btnDivide = new Button();
            btnIgual = new Button();
            btnClear = new Button();
            btnPunto = new Button();
            btnBack = new Button();
            SuspendLayout();
            // 
            // txtDisplay
            // 
            txtDisplay.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            txtDisplay.Location = new Point(12, 45);
            txtDisplay.Name = "txtDisplay";
            txtDisplay.ReadOnly = true;
            txtDisplay.Size = new Size(260, 39);
            txtDisplay.TabIndex = 1;
            txtDisplay.TextAlign = HorizontalAlignment.Right;
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(260, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Calculadora";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn0
            // 
            btn0.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btn0.Location = new Point(12, 272);
            btn0.Name = "btn0";
            btn0.Size = new Size(60, 50);
            btn0.TabIndex = 3;
            btn0.Text = "0";
            // 
            // btn1
            // 
            btn1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btn1.Location = new Point(12, 216);
            btn1.Name = "btn1";
            btn1.Size = new Size(60, 50);
            btn1.TabIndex = 4;
            btn1.Text = "1";
            // 
            // btn2
            // 
            btn2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btn2.Location = new Point(78, 216);
            btn2.Name = "btn2";
            btn2.Size = new Size(60, 50);
            btn2.TabIndex = 5;
            btn2.Text = "2";
            // 
            // btn3
            // 
            btn3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btn3.Location = new Point(144, 216);
            btn3.Name = "btn3";
            btn3.Size = new Size(60, 50);
            btn3.TabIndex = 6;
            btn3.Text = "3";
            // 
            // btn4
            // 
            btn4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btn4.Location = new Point(12, 160);
            btn4.Name = "btn4";
            btn4.Size = new Size(60, 50);
            btn4.TabIndex = 7;
            btn4.Text = "4";
            // 
            // btn5
            // 
            btn5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btn5.Location = new Point(78, 160);
            btn5.Name = "btn5";
            btn5.Size = new Size(60, 50);
            btn5.TabIndex = 8;
            btn5.Text = "5";
            // 
            // btn6
            // 
            btn6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btn6.Location = new Point(144, 160);
            btn6.Name = "btn6";
            btn6.Size = new Size(60, 50);
            btn6.TabIndex = 9;
            btn6.Text = "6";
            // 
            // btn7
            // 
            btn7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btn7.Location = new Point(12, 104);
            btn7.Name = "btn7";
            btn7.Size = new Size(60, 50);
            btn7.TabIndex = 10;
            btn7.Text = "7";
            // 
            // btn8
            // 
            btn8.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btn8.Location = new Point(78, 104);
            btn8.Name = "btn8";
            btn8.Size = new Size(60, 50);
            btn8.TabIndex = 11;
            btn8.Text = "8";
            // 
            // btn9
            // 
            btn9.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btn9.Location = new Point(144, 104);
            btn9.Name = "btn9";
            btn9.Size = new Size(60, 50);
            btn9.TabIndex = 12;
            btn9.Text = "9";
            // 
            // btnSuma
            // 
            btnSuma.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSuma.Location = new Point(210, 272);
            btnSuma.Name = "btnSuma";
            btnSuma.Size = new Size(60, 50);
            btnSuma.TabIndex = 13;
            btnSuma.Text = "+";
            // 
            // btnResta
            // 
            btnResta.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnResta.Location = new Point(210, 216);
            btnResta.Name = "btnResta";
            btnResta.Size = new Size(60, 50);
            btnResta.TabIndex = 14;
            btnResta.Text = "−";
            // 
            // btnMultiplica
            // 
            btnMultiplica.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnMultiplica.Location = new Point(210, 160);
            btnMultiplica.Name = "btnMultiplica";
            btnMultiplica.Size = new Size(60, 50);
            btnMultiplica.TabIndex = 15;
            btnMultiplica.Text = "×";
            // 
            // btnDivide
            // 
            btnDivide.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDivide.Location = new Point(210, 104);
            btnDivide.Name = "btnDivide";
            btnDivide.Size = new Size(60, 50);
            btnDivide.TabIndex = 16;
            btnDivide.Text = "÷";
            // 
            // btnIgual
            // 
            btnIgual.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnIgual.Location = new Point(144, 272);
            btnIgual.Name = "btnIgual";
            btnIgual.Size = new Size(60, 50);
            btnIgual.TabIndex = 17;
            btnIgual.Text = "=";
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.LightGray;
            btnClear.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClear.Location = new Point(14, 335);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(190, 40);
            btnClear.TabIndex = 2;
            btnClear.Text = "C";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // btnPunto
            // 
            btnPunto.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnPunto.Location = new Point(78, 272);
            btnPunto.Name = "btnPunto";
            btnPunto.Size = new Size(60, 50);
            btnPunto.TabIndex = 18;
            btnPunto.Text = ".";
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnBack.Location = new Point(210, 335);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(60, 40);
            btnBack.TabIndex = 19;
            btnBack.Text = "←";
            btnBack.UseVisualStyleBackColor = true;
            // 
            // FormCalculadora
            // 
            ClientSize = new Size(284, 400);
            Controls.Add(lblTitulo);
            Controls.Add(txtDisplay);
            Controls.Add(btnClear);
            Controls.Add(btn0);
            Controls.Add(btn1);
            Controls.Add(btn2);
            Controls.Add(btn3);
            Controls.Add(btn4);
            Controls.Add(btn5);
            Controls.Add(btn6);
            Controls.Add(btn7);
            Controls.Add(btn8);
            Controls.Add(btn9);
            Controls.Add(btnSuma);
            Controls.Add(btnResta);
            Controls.Add(btnMultiplica);
            Controls.Add(btnDivide);
            Controls.Add(btnIgual);
            Controls.Add(btnPunto);
            Controls.Add(btnBack);
            Name = "FormCalculadora";
            Text = "Calculadora";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtDisplay;
        private System.Windows.Forms.Button btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9;
        private System.Windows.Forms.Button btnSuma, btnResta, btnMultiplica, btnDivide, btnIgual, btnClear, btnPunto, btnBack;
    }
}
