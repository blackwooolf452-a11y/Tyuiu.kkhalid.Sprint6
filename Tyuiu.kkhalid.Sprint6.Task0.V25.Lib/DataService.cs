using System;
using tyuiu.cources.programming.interfaces.Sprint6;
namespace Tyuiu.Kkhalid.Sprint6.Task0.V25.Lib
{
    public class DataService : ISprint6Task0V25
    {
        public double Calculate(int x)
        {
            double numerator = x;
            double denominator = Math.Sqrt(Math.Pow(x, 2) + x);

            // محاسبه مقدار
            double result = numerator / denominator;

            // گرد کردن به 3 رقم اعشار
            return Math.Round(result, 3);
        }
    }
}