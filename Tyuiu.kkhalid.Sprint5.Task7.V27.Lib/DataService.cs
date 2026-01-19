using System;
using System.IO;
using System.Linq;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.Kkhalid.Sprint6.Task7.V27.Lib
{
    public class DataService : ISprint6Task7V27
    {
        public int[,] GetMatrix(string path)
        {
            // خواندن تمام خطوط فایل
            string[] lines = File.ReadAllLines(path);

            // تعیین ابعاد ماتریس
            int rows = lines.Length;
            int cols = lines[0].Split(';').Length;

            int[,] matrix = new int[rows, cols];

            // پر کردن ماتریس
            for (int i = 0; i < rows; i++)
            {
                string[] values = lines[i].Split(';');

                for (int j = 0; j < cols; j++)
                {
                    if (int.TryParse(values[j].Trim(), out int value))
                    {
                        matrix[i, j] = value;
                    }
                    else
                    {
                        matrix[i, j] = 0; // مقدار پیش‌فرض اگر تبدیل نشد
                    }
                }
            }

            return matrix;
        }

        public int[,] ChangeNegativeInFifthRow(int[,] matrix)
        {
            // کپی ماتریس
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[,] resultMatrix = (int[,])matrix.Clone();

            // تغییر اعداد منفی در سطر پنجم (ایندکس 4)
            if (rows >= 5) // اگر ماتریس حداقل ۵ سطر دارد
            {
                int rowIndex = 4; // سطر پنجم (ایندکس 4)

                for (int j = 0; j < cols; j++)
                {
                    if (resultMatrix[rowIndex, j] < 0)
                    {
                        resultMatrix[rowIndex, j] = -1;
                    }
                }
            }

            return resultMatrix;
        }

        public void SaveToCsvFile(int[,] matrix, string path)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 0; i < rows; i++)
                {
                    string[] rowValues = new string[cols];

                    for (int j = 0; j < cols; j++)
                    {
                        rowValues[j] = matrix[i, j].ToString();
                    }

                    writer.WriteLine(string.Join(";", rowValues));
                }
            }
        }
    }
}