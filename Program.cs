using System;
using System.Windows.Forms;

namespace SoftIV_CalculadoraBasica // namespace
{
    // Clase principal
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormCalculadora()); // Inicia la calculadora
        }
    }
}
