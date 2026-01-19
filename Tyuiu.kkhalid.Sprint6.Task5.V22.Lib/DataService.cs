using System;
using System.IO;
using System.Linq;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.Kkhalid.Sprint6.Task5.V22.Lib
{
    public class DataService : ISprint6Task5V22
    {
        public double[] LoadFromDataFile(string path)
        {
            double[] numsArray = new double[0];

            try
            {
                // خواندن همه خطوط فایل
                string[] strNums = File.ReadAllLines(path);

                // تبدیل به آرایه عددی
                numsArray = new double[strNums.Length];
                int count = 0;

                foreach (string line in strNums)
                {
                    string str = line.Replace(',', '.');

                    if (double.TryParse(str, System.Globalization.NumberStyles.Float,
                        System.Globalization.CultureInfo.InvariantCulture, out double num))
                    {
                        numsArray[count] = Math.Round(num, 3);
                        count++;
                    }
                }

                // اگر تعدادی خط خوانده نشد، آرایه را کوچک کن
                if (count < numsArray.Length)
                {
                    Array.Resize(ref numsArray, count);
                }
            }
            catch
            {
                throw new Exception("Ошибка при чтении файла.");
            }

            return numsArray;
        }

        public double[] GetNumbersGreaterThanFive(double[] numbers)
        {
            if (numbers == null) return new double[0];

            // فیلتر اعداد بزرگتر از 5
            return numbers.Where(n => n > 5).ToArray();
        }
    }
}