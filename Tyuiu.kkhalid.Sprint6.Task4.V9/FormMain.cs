using System;
using System.Windows.Forms;
using Tyuiu.Kkhalid.Sprint6.Task4.V9.Lib;


namespace Tyuiu.Kkhalid.Sprint6.Task4.V9
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        DataService ds = new DataService();

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Настройка графика
            chartFunction.ChartAreas[0].AxisX.Title = "Ось X";
            chartFunction.ChartAreas[0].AxisY.Title = "Ось Y";
            chartFunction.Series[0].LegendText = "F(x)";
            chartFunction.Titles.Add("График функции F(x)");
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            try
            {
                int startStep = Convert.ToInt32(textBoxStartStep.Text);
                int stopStep = Convert.ToInt32(textBoxStopStep.Text);

                double[] valueArray = ds.GetMassFunction(startStep, stopStep);

                // Очистка предыдущих данных
                textBoxResult.Text = "";
                chartFunction.Series[0].Points.Clear();

                // Вывод в TextBox и построение графика
                for (int i = 0; i < valueArray.Length; i++)
                {
                    int x = startStep + i;
                    textBoxResult.AppendText($"F({x}) = {valueArray[i]}" + Environment.NewLine);
                    chartFunction.Series[0].Points.AddXY(x, valueArray[i]);
                }

                buttonSave.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                string path = $@"{Application.StartupPath}\OutPutFileTask4V9.txt";
                int startStep = Convert.ToInt32(textBoxStartStep.Text);
                int stopStep = Convert.ToInt32(textBoxStopStep.Text);

                ds.SaveToFile(startStep, stopStep, path);

                MessageBox.Show("Файл сохранен: " + path, "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Таск 4, Вариант 9. Выполнил: Халид К.К.", "Информация о задании", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}