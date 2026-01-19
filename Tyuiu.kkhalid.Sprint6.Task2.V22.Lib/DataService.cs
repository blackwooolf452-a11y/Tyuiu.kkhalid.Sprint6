using System;
using tyuiu.cources.programming.interfaces.Sprint6;


namespace Tyuiu.Kkhalid.Sprint6.Task2.V22.Lib
{
    public class DataService : ISprint6Task2V22
    {
      

        double[] ISprint6Task2V22.GetMassFunction(int startValue, int stopValue)
        {
            int len = stopValue - startValue + 1;
            double[,] valueArray = new double[len, 2];

            int count = 0;
            for (int x = startValue; x <= stopValue; x++)
            {
                double denominator = Math.Cos(x) + x;

                valueArray[count, 0] = x;

                if (Math.Abs(denominator) < 0.000001)
                {
                    valueArray[count, 1] = 0;
                }
                else
                {
                    double numerator = (2 * x) - 3;
                    double result = (numerator / denominator) + 5;
                    valueArray[count, 1] = Math.Round(result, 2);
                }
                count++;
            }
            return valueArray;
        }

    }
}




   