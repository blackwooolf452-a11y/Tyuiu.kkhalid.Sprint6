using System;
using System.Windows.Forms;
using Tyuiu.Kkhalid.Sprint6.Task7.V27.Lib;
using System.IO;

namespace Tyuiu.Kkhalid.Sprint6.Task7.V27
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        DataService ds = new DataService();
        int[,] originalMatrix;
        int[,] modifiedMatrix;
        string loadedFilePath = "";

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialogTask.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialogTask.FileName = "InPutFileTask7V27.csv";

                if (openFileDialogTask.ShowDialog() == DialogResult.OK)
                {
                    loadedFilePath = openFileDialogTask.FileName;

                    // خواندن ماتریس
                    originalMatrix = ds.GetMatrix(loadedFilePath);

                    // نمایش ماتریس اصلی
                    DisplayMatrix(dataGridViewIn, originalMatrix);

                    // فعال کردن دکمه پردازش
                    buttonProcess.Enabled = true;
                    buttonSave.Enabled = false;

                    labelStatus.Text = $"Файл загружен: {Path.GetFileName(loadedFilePath)}";
                    labelStatus.Text += $" | Размер: {originalMatrix.GetLength(0)}x{originalMatrix.GetLength(1)}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке файла: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (originalMatrix == null)
                {
                    MessageBox.Show("Сначала загрузите файл", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // تغییر اعداد منفی در سطر پنجم
                modifiedMatrix = ds.ChangeNegativeInFifthRow(originalMatrix);

                // نمایش ماتریس تغییر یافته
                DisplayMatrix(dataGridViewOut, modifiedMatrix);

                // فعال کردن دکمه ذخیره
                buttonSave.Enabled = true;

                labelStatus.Text = $"Обработка завершена. Изменены отрицательные числа в 5-й строке";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обработке: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (modifiedMatrix == null)
                {
                    MessageBox.Show("Сначала обработайте данные", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                saveFileDialogTask.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                saveFileDialogTask.FileName = "OutPutFileTask7V27.csv";

                if (saveFileDialogTask.ShowDialog() == DialogResult.OK)
                {
                    string savePath = saveFileDialogTask.FileName;

                    // ذخیره فایل
                    ds.SaveToCsvFile(modifiedMatrix, savePath);

                    MessageBox.Show($"Результат сохранен в файл:\n{savePath}",
                        "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Таск 7, Вариант 27\n" +
                          "Загрузить CSV файл с матрицей\n" +
                          "Изменить в 5-й строке отрицательные числа на -1\n" +
                          "Вывести результат\n" +
                          "Сохранить в CSV файл\n" +
                          "Выполнил: Халид К.К.",
                          "Информация о задании",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DisplayMatrix(DataGridView dataGridView, int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // پاک کردن ستون‌های قبلی
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();

            // ایجاد ستون‌ها
            for (int j = 0; j < cols; j++)
            {
                dataGridView.Columns.Add($"col{j}", $"Col {j + 1}");
                dataGridView.Columns[j].Width = 50;
            }

            // اضافه کردن سطرها
            for (int i = 0; i < rows; i++)
            {
                dataGridView.Rows.Add();

                for (int j = 0; j < cols; j++)
                {
                    dataGridView.Rows[i].Cells[j].Value = matrix[i, j];

                    // هایلایت سطر پنجم
                    if (i == 4) // سطر پنجم
                    {
                        dataGridView.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.LightYellow;

                        // هایلایت اعداد منفی که تغییر کرده‌اند
                        if (matrix[i, j] == -1 && originalMatrix != null && originalMatrix[i, j] < 0)
                        {
                            dataGridView.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.LightCoral;
                            dataGridView.Rows[i].Cells[j].Style.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
        }
    }
}