using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Tyuiu.Kkhalid.Sprint6.Task2.V22.Lib;

namespace Tyuiu.Kkhalid.Sprint6.Task2.V22
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
                ISprint6Task2V22 ds = new DataService(); // استفاده از اینترفیس
                int startStep = Convert.ToInt32(textBoxStart.Text);
                int stopStep = Convert.ToInt32(textBoxStop.Text);

                if (startStep > stopStep)
                {
                    MessageBox.Show("Начальное значение должно быть меньше или равно конечному", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double[,] valueArray = ds.GetMassFunction(startStep, stopStep);

                // تنظیم DataGridView
                dataGridViewResult.Rows.Clear();
                dataGridViewResult.ColumnCount = 2;
                dataGridViewResult.Columns[0].Width = 50;
                dataGridViewResult.Columns[1].Width = 100;
                dataGridViewResult.Columns[0].HeaderText = "X";
                dataGridViewResult.Columns[1].HeaderText = "F(X)";

                for (int i = 0; i < valueArray.GetLength(0); i++)
                {
                    dataGridViewResult.Rows.Add(valueArray[i, 0], valueArray[i, 1]);
                }
            }
            catch
            {
                MessageBox.Show("Введены неверные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Табулирование функции F(x) = (2x-3)/(cos(x)+x) + 5\nна отрезке [-5; 5] с шагом 1.\nВыполнил: Халид К.", "Справка");
        }
    }
}