using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.Kkhalid.Sprint6.Task2.V22.Lib;

namespace Tyuiu.Kkhalid.Sprint6.Task2.V22.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidGetMassFunction()
        {
            DataService ds = new DataService();

            int start = -5;
            int stop = 5;

            double[,] res = ds.GetMassFunction(start, stop);

            double[,] wait = {
                { -5, -2.57 }, { -4, -1.97 }, { -3, -1.58 },
                { -2, -1.18 }, { -1, -0.72 }, { 0, 2.00 },
                { 1, 4.35 }, { 2, 3.27 }, { 3, 2.70 },
                { 4, 2.47 }, { 5, 2.34 }
            };

            // بررسی ابعاد آرایه
            Assert.AreEqual(wait.GetLength(0), res.GetLength(0));
            Assert.AreEqual(wait.GetLength(1), res.GetLength(1));

            // بررسی مقادیر
            for (int i = 0; i < wait.GetLength(0); i++)
            {
                Assert.AreEqual(wait[i, 0], res[i, 0]);
                Assert.AreEqual(wait[i, 1], res[i, 1]);
            }
        }

        [TestMethod]
        public void ValidGetMassFunction_SingleValue()
        {
            DataService ds = new DataService();

            int start = 0;
            int stop = 0;

            double[,] res = ds.GetMassFunction(start, stop);

            Assert.AreEqual(1, res.GetLength(0));
            Assert.AreEqual(2, res.GetLength(1));
            Assert.AreEqual(0, res[0, 0]);
            Assert.AreEqual(2.00, res[0, 1]);
        }

        [TestMethod]
        public void ValidGetMassFunction_Range()
        {
            DataService ds = new DataService();

            int start = -2;
            int stop = 2;

            double[,] res = ds.GetMassFunction(start, stop);

            Assert.AreEqual(5, res.GetLength(0)); // -2, -1, 0, 1, 2
            Assert.AreEqual(2, res.GetLength(1));
        }
    }
}