using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.Kkhalid.Sprint6.Task0.V25.Lib;

namespace Tyuiu.Kkhalid.Sprint6.Task0.V25.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidCalculate()
        {
            DataService ds = new DataService();

            // تست برای x = 3
            double result = ds.Calculate(3);
            double wait = 0.866;

            Assert.AreEqual(wait, result);
        }

        [TestMethod]
        public void CheckRounding()
        {
            DataService ds = new DataService();
            double result = ds.Calculate(3);

            // بررسی گرد شدن به 3 رقم اعشار
            string resultStr = result.ToString("F3");
            Assert.AreEqual("0.866", resultStr);
        }
    }
}