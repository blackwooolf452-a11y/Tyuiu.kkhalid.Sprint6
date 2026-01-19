using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.Kkhalid.Sprint6.Task4.V9.Lib
{
    public class DataService : ISprint6Task4V9
    {
        public double[] GetMassFunction(int startValue, int stopValue)
        {
            int len = (stopValue - startValue) + 1;
            double[] valueArray = new double[len];
            int count = 0;

            for (int x = startValue; x <= stopValue; x++)
            {
                try
                {
                    // محاسبه با دقت بیشتر
                    double cosx = Math.Cos(x);
                    double sinx = Math.Sin(x);

                    // مخرج
                    double denominator = cosx - 2 * x;

                    // بررسی تقسیم بر صفر
                    if (Math.Abs(denominator) < 0.0000001)
                    {
                        valueArray[count] = 0;
                    }
                    else
                    {
                        // صورت
                        double numerator = 2 * x - 3;

                        // کسر
                        double fraction = numerator / denominator;

                        // بخش دوم
                        double secondPart = 5 * x - sinx;

                        // نتیجه نهایی
                        double result = fraction + secondPart;

                        valueArray[count] = Math.Round(result, 2);
                    }
                }
                catch
                {
                    valueArray[count] = 0;
                }

                count++;
            }

            return valueArray;
        }

        public string SaveToFile(int startValue, int stopValue, string path)
        {
            string directory = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            double[] values = GetMassFunction(startValue, stopValue);

            using (StreamWriter writer = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            {
                writer.WriteLine("**************************");
                writer.WriteLine("* Таблица значений функции *");
                writer.WriteLine("**************************");
                writer.WriteLine($"* Функция: F(x) = (2x-3)/(cos(x)-2x) + 5x - sin(x)");
                writer.WriteLine($"* Диапазон: от {startValue} до {stopValue}");
                writer.WriteLine("**************************");
                writer.WriteLine("|    X    |    F(x)    |");
                writer.WriteLine("--------------------------");

                int index = 0;
                for (int x = startValue; x <= stopValue; x++)
                {
                    writer.WriteLine($"| {x,5}   | {values[index],9:F2} |");
                    index++;
                }

                writer.WriteLine("**************************");
                writer.WriteLine("Проект: Tyuiu.Kkhalid.Sprint6.Task4.V9");
            }

            return path;
        }
    }
}