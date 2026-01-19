using System;
using System.Windows.Forms;
using Tyuiu.kkhalid.Sprint6.Task5.V22;

namespace Tyuiu.Kkhalid.Sprint6.Task5.V22
{
    static class Program
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