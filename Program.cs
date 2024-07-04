using System;
using System.Windows.Forms;

namespace GPA_Calculator
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GPA_Cal_Form());
        }
    }
}
