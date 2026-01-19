using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.Kkhalid.Sprint6.Task1.V13.Lib;

namespace Tyuiu.Kkhalid.Sprint6.Task1.V13.Test
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
            double[] res = ds.GetMassFunction(start, stop);
            double[] wait =  { 15.03, 11.04, 8.07, 4.93, 1.68, 0, -1.68, -4.93, -8.07, -11.04, -15.03 };
            CollectionAssert.AreEqual(wait, res);
        }
    }
}