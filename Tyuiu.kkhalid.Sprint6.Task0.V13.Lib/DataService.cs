using System;
using tyuiu.cources.programming.interfaces.Sprint6;
namespace Tyuiu.kkhalid.Sprint6.Task1.V13.Lib
{
    public class DataService:ISprint6Task1V13
    {
        public double[] GetMassFunction(int startValue, int stopValue)
        {
            int len = stopValue - startValue + 1;
            double[] valueArray = new double[len];

            int count = 0;
            for (int x = startValue; x <= stopValue; x++)
            {
                double denominator = 4 * Math.Pow(x, 2) + 5;

                if (Math.Abs(denominator) < 0.0001)
                {
                    valueArray[count] = 0;
                }
                else
                {
                    double part1 = 3 * Math.Cos(x) / denominator;
                    double part2 = Math.Sin(x) - 5 * x - 2;
                    valueArray[count] = Math.Round(part1 + part2, 2);
                }
                count++;
            }
            return valueArray;
        }
    }
}