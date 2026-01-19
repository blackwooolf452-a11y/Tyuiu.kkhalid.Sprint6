using System;

namespace Tyuiu.kkhalid.Sprint6.Task1.V13.Lib
{
    public class DataService
    {
        public double[] GetMassFunction(int startValue, int stopValue)
        {
            int len = stopValue - startValue + 1;
            double[] valueArray = new double[len];

            int count = 0;
            for (int x = startValue; x <= stopValue; x++)
            {
                valueArray[count] = CalculateFunction(x);
                count++;
            }
            return valueArray;
        }

        private double CalculateFunction(int x)
        {
            // تابع اصلی Task0/Task1
            // F(x) = (3cos(x))/(4x²+5) + sin(x) - 5x - 2

            double denominator = 4 * Math.Pow(x, 2) + 5;

            // بررسی تقسیم بر صفر
            if (Math.Abs(denominator) < 0.0001)
            {
                return 0;
            }

            // محاسبه دقیق
            double cosValue = Math.Cos(x);
            double sinValue = Math.Sin(x);

            double part1 = 3 * cosValue / denominator;
            double part2 = sinValue - 5 * x - 2;
            double result = part1 + part2;

            // گرد کردن
            return Math.Round(result, 2);
        }
    }
}