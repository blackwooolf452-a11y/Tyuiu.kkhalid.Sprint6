using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Tyuiu.Kkhalid.Sprint6.Task1.V13.Lib;

namespace Tyuiu.Kkhalid.Sprint6.Task1.V13
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            try
            {
                DataService ds = new DataService();
                int startStep = Convert.ToInt32(textBoxStart.Text);
                int stopStep = Convert.ToInt32(textBoxStop.Text);

                if (startStep > stopStep)
                {
                    MessageBox.Show("Начальное значение должно быть меньше или равно конечному", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int len = stopStep - startStep + 1;
                double[] valueArray = ds.GetMassFunction(startStep, stopStep);

                textBoxResult.Text = "";
                textBoxResult.AppendText("+----------+----------+" + Environment.NewLine);
                textBoxResult.AppendText("|    x     |   f(x)   |" + Environment.NewLine);
                textBoxResult.AppendText("+----------+----------+" + Environment.NewLine);

                for (int i = 0; i < len; i++)
                {
                    string strLine = String.Format("| {0,5:d}    | {1,7:f2}  |", startStep + i, valueArray[i]);
                    textBoxResult.AppendText(strLine + Environment.NewLine);
                }

                textBoxResult.AppendText("+----------+----------+" + Environment.NewLine);
            }
            catch
            {
                MessageBox.Show("Введены неверные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Табулирование функции F(x) = (3cos(x))/(4x-0.5) + sin(x) - 5x - 2\nна отрезке [-5; 5] с шагом 1.\nВыполнил: Халид К.", "Справка");
        }
    }
}