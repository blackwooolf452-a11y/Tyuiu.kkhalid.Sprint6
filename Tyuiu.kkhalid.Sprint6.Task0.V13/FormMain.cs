using System;
using System.Windows.Forms;
using Tyuiu.kkhalid.Sprint6.Task1.V13.Lib;

namespace Tyuiu.kkhalid.Sprint6.Task1.V13
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            textBoxOutput.Clear();
            textBoxOutput.AppendText("x\tF(x)" + Environment.NewLine);
            textBoxOutput.AppendText("----------------" + Environment.NewLine);

            DataService ds = new DataService();

            for (int x = -5; x <= 5; x++)
            {
                double result = ds.Calculate(x);
                textBoxOutput.AppendText($"{x}\t{result:F2}" + Environment.NewLine);
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Task1 V13 выполнил студент группы ИИПб-23-3 Халид Х.А.",
                          "Справка",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }
    }
}