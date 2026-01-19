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

            double[] wait = { -23.42, -17.65, -12.54, -8.12, -4.33, -2.00, -6.33, -12.12, -17.54, -22.65, -27.42 };

            CollectionAssert.AreEqual(wait, result);
        }
    }
}