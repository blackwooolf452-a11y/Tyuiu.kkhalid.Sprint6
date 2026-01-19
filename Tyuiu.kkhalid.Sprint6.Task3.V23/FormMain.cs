using System;
using System.Windows.Forms;
using Tyuiu.Kkhalid.Sprint6.Task3.V23.Lib;

namespace Tyuiu.Kkhalid.Sprint6.Task3.V23
{
    public partial class  FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        DataService ds = new DataService();
        int[,] matrix = new int[5, 5]
        {
            { 0, -19, 25, 34, 0 },
            { -19, -16, 1, -5, 34 },
            { 1, 13, -5, -17, -5 },
            { 3, -9, -15, -1, 0 },
            { 1, 20, 15, -5, 31 }
        };

        private void FormMain_Load(object sender, EventArgs e)
        {
            // نمایش ماتریس اصلی
            dataGridViewMatrix.ColumnCount = 5;
            dataGridViewMatrix.RowCount = 5;

            for (int i = 0; i < 5; i++)
            {
                dataGridViewMatrix.Columns[i].Width = 50;
                for (int j = 0; j < 5; j++)
                {
                    dataGridViewMatrix.Rows[i].Cells[j].Value = matrix[i, j];
                }
            }
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            int[,] sortedMatrix = ds.Calculate(matrix);

            // نمایش ماتریس مرتب‌شده
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    dataGridViewMatrix.Rows[i].Cells[j].Value = sortedMatrix[i, j];
                }
            }
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Task3 V23. Выполнил: Халид К.К.", "Информация о задании", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}