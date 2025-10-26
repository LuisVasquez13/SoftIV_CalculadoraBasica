using System;
using System.Windows.Forms;

namespace SoftIV_CalculadoraBasica
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormCalculadora());
        }
    }
}
