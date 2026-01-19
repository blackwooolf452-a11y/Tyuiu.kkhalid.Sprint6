using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.Kkhalid.Sprint6.Task3.V23.Lib;

namespace Tyuiu.Kkhalid.Sprint6.Task3.V23.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidCalculate() 
        {
            DataService ds = new DataService();

            int[,] matrix = new int[5, 5]
            {
                { 0, -19, 25, 34, 0 },
                { -19, -16, 1, -5, 34 },
                { 1, 13, -5, -17, -5 },
                { 3, -9, -15, -1, 0 },
                { 1, 20, 15, -5, 31 }
            };

            int[,] res = ds.Calculate(matrix);
            int[,] wait = new int[5, 5]
            {
                { 0, -19, 25, 34, 0 },
                { -19, -16, 1, -5, 34 },
                { 3, -9, -15, -1, 0 },
                { 1, 13, -5, -17, -5 },
                { 1, 20, 15, -5, 31 }
            };

            CollectionAssert.AreEqual(wait, res);
        }

        [TestMethod]
        public void CheckSecondColumnSorted()
        {
            DataService ds = new DataService();

            int[,] matrix = new int[5, 5]
            {
                { 0, -19, 25, 34, 0 },
                { -19, -16, 1, -5, 34 },
                { 1, 13, -5, -17, -5 },
                { 3, -9, -15, -1, 0 },
                { 1, 20, 15, -5, 31 }
            };

            int[,] res = ds.Calculate(matrix);

            // Проверяем, что второй столбец отсортирован по возрастанию
            int[] secondColumn = new int[5];
            for (int i = 0; i < 5; i++)
            {
                secondColumn[i] = res[i, 1];
            }

            bool isSorted = true;
            for (int i = 0; i < 4; i++)
            {
                if (secondColumn[i] > secondColumn[i + 1])
                {
                    isSorted = false;
                    break;
                }
            }

            Assert.IsTrue(isSorted);
        }

        [TestMethod]
        public void CheckRowsRearrangedCorrectly()
        {
            DataService ds = new DataService();

            int[,] matrix = new int[5, 5]
            {
                { 0, -19, 25, 34, 0 },
                { -19, -16, 1, -5, 34 },
                { 1, 13, -5, -17, -5 },
                { 3, -9, -15, -1, 0 },
                { 1, 20, 15, -5, 31 }
            };

            int[,] res = ds.Calculate(matrix);

            // Проверяем, что строки перемещены целиком
            // Строка с -19 во втором столбце должна быть первой
            Assert.AreEqual(-19, res[0, 1]);
            Assert.AreEqual(0, res[0, 0]);
            Assert.AreEqual(25, res[0, 2]);
            Assert.AreEqual(34, res[0, 3]);
            Assert.AreEqual(0, res[0, 4]);

            // Строка с -16 во втором столбце должна быть второй
            Assert.AreEqual(-16, res[1, 1]);
            Assert.AreEqual(-19, res[1, 0]);
            Assert.AreEqual(1, res[1, 2]);
            Assert.AreEqual(-5, res[1, 3]);
            Assert.AreEqual(34, res[1, 4]);
        }
    }
}
