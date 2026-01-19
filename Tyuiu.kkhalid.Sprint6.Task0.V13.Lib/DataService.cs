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
                valueArray[count] = Math.Round(Calculate(x), 2);
                count++;
            }

            return valueArray;
        }

        public double Calculate(int x)
        {
            double denominator = 4 * Math.Pow(x, 2) + 5;

            // بررسی تقسیم بر صفر
            if (Math.Abs(denominator) < 0.0001)
            {
                return 0;
            }

            double cosValue = Math.Cos(x);
            double sinValue = Math.Sin(x); // اینجا sin(-5) = -0.9589 خواهد بود

            double part1 = 3 * cosValue / denominator;
            double part2 = sinValue - 5 * x - 2;
            double result = part1 + part2;

            return result;
        }
    }
}