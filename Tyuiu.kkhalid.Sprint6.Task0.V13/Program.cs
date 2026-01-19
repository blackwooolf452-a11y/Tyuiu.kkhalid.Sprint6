using System;
using System.Windows.Forms;

namespace Tyuiu.kkhalid.Sprint6.Task1.V13
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}