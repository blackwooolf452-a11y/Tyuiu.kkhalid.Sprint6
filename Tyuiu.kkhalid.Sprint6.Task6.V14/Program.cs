using System;
using System.Windows.Forms;

namespace Tyuiu.Kkhalid.Sprint6.Task6.V14
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