using System;
using System.Windows.Forms;
using Tyuiu.Kkhalid.Sprint6.Task5.V22.Lib;

using System.IO;

namespace Tyuiu.Kkhalid.Sprint6.Task5.V22
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        DataService ds = new DataService();
        double[] numsArray;
        double[] filteredNums;

        private void FormMain_Load(object sender, EventArgs e)
        {
            // تنظیم DataGridView
            dataGridViewNums.ColumnCount = 2;
            dataGridViewNums.Columns[0].HeaderText = "№";
            dataGridViewNums.Columns[0].Width = 50;
            dataGridViewNums.Columns[1].HeaderText = "Значение";
            dataGridViewNums.Columns[1].Width = 100;

            // تنظیم Chart
            chartNums.ChartAreas[0].AxisX.Title = "Индекс";
            chartNums.ChartAreas[0].AxisY.Title = "Значение";
            chartNums.Series[0].LegendText = "Числа > 5";
            chartNums.Titles.Add("Диаграмма чисел больше 5");

            buttonSave.Enabled = false;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string path = $@"{Application.StartupPath}\InPutFileTask5V22.txt";

                if (!File.Exists(path))
                {
                    MessageBox.Show($"Файл {path} не найден!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // خواندن از فایل
                numsArray = ds.LoadFromDataFile(path);

                // فیلتر کردن
                filteredNums = ds.GetNumbersGreaterThanFive(numsArray);

                // نمایش در DataGridView
                DisplayInDataGridView();

                // نمایش در TextBox
                DisplayInTextBox();

                // رسم نمودار
                DrawChart();

                buttonSave.Enabled = true;
                labelStatus.Text = $"Загружено: {filteredNums.Length} чисел > 5";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayInDataGridView()
        {
            dataGridViewNums.Rows.Clear();

            for (int i = 0; i < filteredNums.Length; i++)
            {
                dataGridViewNums.Rows.Add(i + 1, filteredNums[i]);
            }
        }

        private void DisplayInTextBox()
        {
            textBoxResult.Clear();

            textBoxResult.AppendText("ЧИСЛА БОЛЬШЕ 5:\r\n");
            textBoxResult.AppendText("===============\r\n\r\n");

            for (int i = 0; i < filteredNums.Length; i++)
            {
                textBoxResult.AppendText($"{i + 1}. {filteredNums[i]:F3}\r\n");
            }

            textBoxResult.AppendText($"\r\nВсего: {filteredNums.Length} чисел");
        }

        private void DrawChart()
        {
            chartNums.Series[0].Points.Clear();
            chartNums.Series[0].ChartType = SeriesChartType.Column;

            for (int i = 0; i < filteredNums.Length; i++)
            {
                chartNums.Series[0].Points.AddXY(i + 1, filteredNums[i]);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                string path = $@"{Application.StartupPath}\OutPutFileTask5V22.txt";

                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.WriteLine("РЕЗУЛЬТАТЫ ОБРАБОТКИ ФАЙЛА");
                    writer.WriteLine("===========================");
                    writer.WriteLine($"Файл: InPutFileTask5V22.txt");
                    writer.WriteLine($"Дата: {DateTime.Now}");
                    writer.WriteLine();
                    writer.WriteLine($"Всего чисел в файле: {numsArray.Length}");
                    writer.WriteLine($"Чисел больше 5: {filteredNums.Length}");
                    writer.WriteLine();
                    writer.WriteLine("СПИСОК ЧИСЕЛ БОЛЬШЕ 5:");
                    writer.WriteLine("----------------------");

                    for (int i = 0; i < filteredNums.Length; i++)
                    {
                        writer.WriteLine($"{i + 1}. {filteredNums[i]:F3}");
                    }
                }

                MessageBox.Show($"Результаты сохранены в файл:\n{path}",
                    "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Таск 5, Вариант 22\n" +
                          "Прочитать данные из файла InPutFileTask5V22.txt\n" +
                          "Вывести в dataGridView числа больше 5\n" +
                          "Построить диаграмму\n" +
                          "Выполнил: Халид К.К.",
                          "Информация о задании",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}