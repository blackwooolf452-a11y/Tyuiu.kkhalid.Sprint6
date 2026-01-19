using System;
using System.Windows.Forms;
using Tyuiu.Kkhalid.Sprint6.Task6.V14.Lib;

namespace Tyuiu.Kkhalid.Sprint6.Task6.V14
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        DataService ds = new DataService();
        string filePath = "";

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialogTask.ShowDialog();
                filePath = openFileDialogTask.FileName;

                if (string.IsNullOrEmpty(filePath) || !System.IO.File.Exists(filePath))
                {
                    MessageBox.Show("Файл не выбран или не существует", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // نمایش مسیر فایل
                textBoxInput.Text = $"Файл: {filePath}" + Environment.NewLine + Environment.NewLine;

                // خواندن محتوای فایل
                string fileContent = System.IO.File.ReadAllText(filePath, System.Text.Encoding.UTF8);
                textBoxInput.AppendText(fileContent);

                // فعال کردن دکمه обработки
                buttonProcess.Enabled = true;
                buttonSave.Enabled = false;

                labelStatus.Text = $"Файл загружен: {System.IO.Path.GetFileName(filePath)}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии файла: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath) || !System.IO.File.Exists(filePath))
                {
                    MessageBox.Show("Сначала выберите файл", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // پردازش فایل و پیدا کردن کلمات с буквой 'z'
                string result = ds.CollectTextFromFile(filePath);

                // نمایش نتیجه
                textBoxOutput.Clear();

                if (string.IsNullOrEmpty(result))
                {
                    textBoxOutput.Text = "Слова с буквой 'z' не найдены.";
                }
                else
                {
                    textBoxOutput.Text = "Слова содержащие букву 'z':" + Environment.NewLine;
                    textBoxOutput.AppendText("==================================" + Environment.NewLine);
                    textBoxOutput.AppendText(result);

                    // شمارش کلمات
                    int wordCount = result.Split(new[] { Environment.NewLine },
                        StringSplitOptions.RemoveEmptyEntries).Length;

                    textBoxOutput.AppendText(Environment.NewLine + Environment.NewLine);
                    textBoxOutput.AppendText($"Найдено слов: {wordCount}");
                }

                buttonSave.Enabled = true;
                labelStatus.Text = $"Обработка завершена. Файл: {System.IO.Path.GetFileName(filePath)}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обработке файла: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialogTask.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                saveFileDialogTask.FileName = "OutputFileTask6V14.txt";

                if (saveFileDialogTask.ShowDialog() == DialogResult.OK)
                {
                    string savePath = saveFileDialogTask.FileName;

                    System.IO.File.WriteAllText(savePath, textBoxOutput.Text, System.Text.Encoding.UTF8);

                    MessageBox.Show($"Результат сохранен в файл:{Environment.NewLine}{savePath}",
                        "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Таск 6, Вариант 14\n" +
                          "Загрузить файл через openFileDialog\n" +
                          "Найти слова содержащие букву 'z'\n" +
                          "Вывести результат\n" +
                          "Выполнил: Халид К.К.",
                          "Информация о задании",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}