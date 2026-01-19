using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tyuiu.cources.programming.interfaces.Sprint6;
namespace Tyuiu.Kkhalid.Sprint6.Task3.V23.Lib
{
    public class DataService : ISprint6Task3V23
    {
        public int[,] Calculate(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // کپی ماتریس برای تغییر
            int[,] resultMatrix = (int[,])matrix.Clone();

            // مرتب‌سازی سطرها بر اساس ستون دوم (ایندکس 1)
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = i + 1; j < rows; j++)
                {
                    if (resultMatrix[i, 1] > resultMatrix[j, 1])
                    {
                        // جابجایی سطرها
                        for (int k = 0; k < cols; k++)
                        {
                            int temp = resultMatrix[i, k];
                            resultMatrix[i, k] = resultMatrix[j, k];
                            resultMatrix[j, k] = temp;
                        }
                    }
                }
            }

            return resultMatrix;
        }
    }
}