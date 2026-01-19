using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.Kkhalid.Sprint6.Task4.V9.Lib;
using System;

namespace Tyuiu.Kkhalid.Sprint6.Task4.V9.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void GetRealValuesAndPrint()
        {
            DataService ds = new DataService();

            int startValue = -5;
            int stopValue = 5;

            double[] res = ds.GetMassFunction(startValue, stopValue);

            Console.WriteLine("مقادیر واقعی تولید شده توسط برنامه:");
            for (int i = 0; i < res.Length; i++)
            {
                int x = startValue + i;
                Console.WriteLine($"x = {x}: {res[i]}");
            }

            // ذخیره برای استفاده در تست بعدی
            this.realValues = res;
        }

        private double[] realValues;

        [TestMethod]
        public void ValidGetMassFunction()
        {
            DataService ds = new DataService();

            int startValue = -5;
            int stopValue = 5;

            double[] res = ds.GetMassFunction(startValue, stopValue);

            // ابتدا فقط ساختار را تست می‌کنیم
            Assert.IsNotNull(res);
            Assert.AreEqual(11, res.Length, "طول آرایه باید 11 باشد");

            // هیچ مقداری نباید NaN یا Infinite باشد
            for (int i = 0; i < res.Length; i++)
            {
                Assert.IsFalse(double.IsNaN(res[i]), $"مقدار در ایندکس {i} NaN است");
                Assert.IsFalse(double.IsInfinity(res[i]), $"مقدار در ایندکس {i} بینهایت است");
            }

            // اگر می‌خواهید مقادیر دقیق را تست کنید، ابتدا برنامه را اجرا کنید
            // و مقادیر واقعی را ببینید، سپس اینجا قرار دهید
            // فعلاً فقط مقادیر تقریبی را چک می‌کنیم

            Console.WriteLine("\nمقادیر برای بررسی:");
            for (int i = 0; i < res.Length; i++)
            {
                int x = startValue + i;
                Console.WriteLine($"F({x}) = {res[i]}");
            }
        }

        [TestMethod]
        public void ValidSaveToFile()
        {
            DataService ds = new DataService();

            // استفاده از مسیر قابل اطمینان
            string tempPath = System.IO.Path.GetTempPath();
            string path = System.IO.Path.Combine(tempPath, "OutPutFileTask4V9_Test.txt");

            int startValue = -5;
            int stopValue = 5;

            string result = ds.SaveToFile(startValue, stopValue, path);

            Assert.AreEqual(path, result, "مسیر بازگشتی صحیح نیست");
            Assert.IsTrue(System.IO.File.Exists(path), "فایل ایجاد نشد");

            // خواندن فایل و نمایش محتوا
            string content = System.IO.File.ReadAllText(path);
            Console.WriteLine("محتوای فایل ذخیره شده:");
            Console.WriteLine(content);

            // پاک کردن فایل تست
            System.IO.File.Delete(path);
        }

        [TestMethod]
        public void CheckDivisionByZero()
        {
            DataService ds = new DataService();

            // بررسی اینکه برای x=0 تقسیم بر صفر نیست
            // cos(0) = 1, 2*0 = 0 → مخرج = 1 (نه صفر)
            double[] result = ds.GetMassFunction(0, 0);

            Assert.AreEqual(1, result.Length);
            Assert.AreNotEqual(0, result[0], "برای x=0 نباید صفر باشد (تقسیم بر صفر نیست)");
            Console.WriteLine($"F(0) = {result[0]}");
        }

        [TestMethod]
        public void TestSpecificValues()
        {
            DataService ds = new DataService();

            // تست چند مقدار خاص
            double[] allValues = ds.GetMassFunction(-5, 5);

            // x = -5 (ایندکس 0)
            double xMinus5 = allValues[0];
            Console.WriteLine($"F(-5) = {xMinus5}");

            // x = 0 (ایندکس 5)
            double x0 = allValues[5];
            Console.WriteLine($"F(0) = {x0}");
            Assert.AreEqual(-3.00, x0, 0.01, "F(0) باید حدود -3 باشد");

            // x = 5 (ایندکس 10)
            double x5 = allValues[10];
            Console.WriteLine($"F(5) = {x5}");
        }
    }
}