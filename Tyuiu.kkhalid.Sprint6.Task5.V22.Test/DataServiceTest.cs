using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.Kkhalid.Sprint6.Task5.V22.Lib;
using System.IO;

namespace Tyuiu.Kkhalid.Sprint6.Task5.V22.Test
{
    [TestClass]
    public class SimpleDataServiceTest
    {
        [TestMethod]
        public void Test1_LoadFile()
        {
            DataService ds = new DataService();

            // ایجاد فایل ساده
            string path = "test1.txt";
            File.WriteAllText(path, "10.5\n20.3\n30.7");

            double[] result = ds.LoadFromDataFile(path);

            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(10.5, result[0]);
            Assert.AreEqual(20.3, result[1]);
            Assert.AreEqual(30.7, result[2]);

            File.Delete(path);
        }

        [TestMethod]
        public void Test2_FilterNumbers()
        {
            DataService ds = new DataService();

            double[] numbers = { 1, 5, 6, 5.5, 4.9, 7.2 };
            double[] result = ds.GetNumbersGreaterThanFive(numbers);

            Assert.AreEqual(3, result.Length); // 6, 5.5, 7.2
        }

        [TestMethod]
        public void Test3_Rounding()
        {
            DataService ds = new DataService();

            string path = "test3.txt";
            File.WriteAllText(path, "12.3456\n7.8912");

            double[] result = ds.LoadFromDataFile(path);

            Assert.AreEqual(12.346, result[0], 0.001);
            Assert.AreEqual(7.891, result[1], 0.001);

            File.Delete(path);
        }
    }
}