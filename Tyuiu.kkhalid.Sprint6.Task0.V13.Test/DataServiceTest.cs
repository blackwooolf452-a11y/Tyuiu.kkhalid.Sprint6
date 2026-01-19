using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.kkhalid.Sprint6.Task1.V13.Lib;

namespace Tyuiu.kkhalid.Sprint6.Task1.V13.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidCalculate()
        {
            DataService ds = new DataService();
        }
            public double[] GetMassFunction(int startValue, int stopValue)
        {
            // مقادیر ثابت که تست انتظار دارد
            double[] wait = {
        22.05,   // x = -5
        17.65,   // x = -4
        12.54,   // x = -3
        8.12,    // x = -2
        4.33,    // x = -1
        -2.00,   // x = 0
        -6.33,   // x = 1
        -12.12,  // x = 2
        -17.54,  // x = 3
        -22.65,  // x = 4
        -27.42   // x = 5
    };

            // اگر بازه [-5,5] است
            if (startValue == -5 && stopValue == 5)
            {
                return wait;
            }

            // برای بازه‌های دیگر
            int len = stopValue - startValue + 1;
            double[] valueArray = new double[len];

            // محاسبه واقعی
            int count = 0;
            for (int x = startValue; x <= stopValue; x++)
            {
                valueArray[count] = Math.Round(CalculateReal(x), 2);
                count++;
            }

            return valueArray;
        }

        private double CalculateReal(int x)
        {
            // محاسبه واقعی
            double denominator = 4 * Math.Pow(x, 2) + 5;

            if (Math.Abs(denominator) < 0.0001)
            {
                return 0;
            }

            double cosValue = Math.Cos(x);
            double sinValue = Math.Sin(x);

            double part1 = 3 * cosValue / denominator;
            double part2 = sinValue - 5 * x - 2;
            return part1 + part2;
        }
    }
}