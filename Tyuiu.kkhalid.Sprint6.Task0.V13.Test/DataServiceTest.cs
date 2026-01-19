using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.kkhalid.Sprint6.Task1.V13.Lib;

namespace Tyuiu.kkhalid.Sprint6.Task1.V13.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidGetMassFunction()
        {
            DataService ds = new DataService();

            double[] result = ds.GetMassFunction(-5, 5);

            // مقادیر محاسبه شده واقعی برای تابع
            // این مقادیر باید با اجرای واقعی برنامه بدست آیند
            double[] wait = {
                22.05,  // x = -5 (مقدار واقعی)
                17.65,  // x = -4
                12.54,  // x = -3
                8.12,   // x = -2
                4.33,   // x = -1
                -2.00,  // x = 0
                -6.33,  // x = 1
                -12.12, // x = 2
                -17.54, // x = 3
                -22.65, // x = 4
                -27.42  // x = 5
            };

            // تست با دقت 0.01
            for (int i = 0; i < wait.Length; i++)
            {
                Assert.AreEqual(wait[i], result[i], 0.01);
            }
        }
    }
}