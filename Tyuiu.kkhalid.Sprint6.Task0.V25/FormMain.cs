using System;
using System.Windows.Forms;
using Tyuiu.Kkhalid.Sprint6.Task0.V25.Lib;

namespace Tyuiu.Kkhalid.Sprint6.Task0.V25
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonCalculate_KHA_Click(object sender, EventArgs e)
        {
            try
            {
                // خواندن مقدار x از TextBox
                int x = Convert.ToInt32(textBoxVarX_KHA.Text);

                // ایجاد نمونه از DataService
                DataService ds = new DataService();

                // محاسبه نتیجه
                double result = ds.Calculate(x);

                // نمایش نتیجه با 3 رقم اعشار
                textBoxResult_KHA.Text = result.ToString("F3");
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите целое число в поле X", "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonHelp_KHA_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Таск 0 выполнил студент группы ИИПБ-23-3 Халид К.\n" +
                "Вычислить выражение y = x / sqrt(x^2 + x) при x = 3",
                "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}