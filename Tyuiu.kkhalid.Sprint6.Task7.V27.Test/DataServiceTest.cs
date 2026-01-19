using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.Kkhalid.Sprint6.Task7.V27.Lib;
using System.IO;

namespace Tyuiu.Kkhalid.Sprint6.Task7.V27.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidGetMatrix()
        {
            DataService ds = new DataService(); 

            // ایجاد فایل CSV تست
            string testFile = "test_matrix.csv";
            string csvContent = @"1;2;3;4
5;-6;7;-8
9;10;11;12
13;-14;15;-16
17;18;-19;20
21;22;23;24";

            File.WriteAllText(testFile, csvContent);

            try
            {
                int[,] matrix = ds.GetMatrix(testFile);

                // بررسی ابعاد
                Assert.AreEqual(6, matrix.GetLength(0)); // سطرها
                Assert.AreEqual(4, matrix.GetLength(1)); // ستون‌ها

                // بررسی برخی مقادیر
                Assert.AreEqual(1, matrix[0, 0]);
                Assert.AreEqual(-6, matrix[1, 1]);
                Assert.AreEqual(-19, matrix[4, 2]); // سطر 5، ستون 3
                Assert.AreEqual(24, matrix[5, 3]);
            }
            finally
            {
                if (File.Exists(testFile))
                    File.Delete(testFile);
            }
        }

        [TestMethod]
        public void ValidChangeNegativeInFifthRow()
        {
            DataService ds = new DataService();

            // ماتریس تست
            int[,] testMatrix = new int[6, 4]
            {
                { 1, 2, 3, 4 },
                { 5, -6, 7, -8 },
                { 9, 10, 11, 12 },
                { 13, -14, 15, -16 },
                { 17, 18, -19, 20 }, // سطر پنجم
                { 21, 22, 23, 24 }
            };

            int[,] result = ds.ChangeNegativeInFifthRow(testMatrix);

            // بررسی تغییرات در سطر پنجم
            Assert.AreEqual(17, result[4, 0]); // مثبت، تغییر نکرد
            Assert.AreEqual(18, result[4, 1]); // مثبت، تغییر نکرد
            Assert.AreEqual(-1, result[4, 2]); // منفی، باید به -1 تغییر کند
            Assert.AreEqual(20, result[4, 3]); // مثبت، تغییر نکرد

            // بررسی عدم تغییر در سطرهای دیگر
            Assert.AreEqual(-6, result[1, 1]); // سطر دوم، تغییر نکرد
            Assert.AreEqual(-8, result[1, 3]); // سطر دوم، تغییر نکرد
            Assert.AreEqual(-14, result[3, 1]); // سطر چهارم، تغییر نکرد
            Assert.AreEqual(-16, result[3, 3]); // سطر چهارم، تغییر نکرد
        }

        [TestMethod]
        public void ValidChangeNegativeInFifthRow_NoNegative()
        {
            DataService ds = new DataService();

            // ماتریس بدون عدد منفی در سطر پنجم
            int[,] testMatrix = new int[5, 3]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 },
                { 10, 11, 12 },
                { 13, 14, 15 } // سطر پنجم بدون اعداد منفی
            };

            int[,] result = ds.ChangeNegativeInFifthRow(testMatrix);

            // باید بدون تغییر باشد
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(testMatrix[i, j], result[i, j]);
                }
            }
        }

        [TestMethod]
        public void ValidChangeNegativeInFifthRow_SmallMatrix()
        {
            DataService ds = new DataService();

            // ماتریس کوچکتر از ۵ سطر
            int[,] testMatrix = new int[3, 3]
            {
                { 1, -2, 3 },
                { -4, 5, -6 },
                { 7, -8, 9 }
            };

            int[,] result = ds.ChangeNegativeInFifthRow(testMatrix);

            // باید بدون تغییر باشد (سطر پنجم وجود ندارد)
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(testMatrix[i, j], result[i, j]);
                }
            }
        }

        [TestMethod]
        public void ValidSaveToCsvFile()
        {
            DataService ds = new DataService();

            // ماتریس تست
            int[,] testMatrix = new int[3, 3]
            {
                { 1, 2, 3 },
                { -4, 5, -6 },
                { 7, 8, 9 }
            };

            string testFile = "test_output.csv";

            try
            {
                // ذخیره فایل
                ds.SaveToCsvFile(testMatrix, testFile);

                // بررسی وجود فایل
                Assert.IsTrue(File.Exists(testFile));

                // خواندن و بررسی محتوا
                string[] lines = File.ReadAllLines(testFile);
                Assert.AreEqual(3, lines.Length);
                Assert.AreEqual("1;2;3", lines[0]);
                Assert.AreEqual("-4;5;-6", lines[1]);
                Assert.AreEqual("7;8;9", lines[2]);
            }
            finally
            {
                if (File.Exists(testFile))
                    File.Delete(testFile);
            }
        }
    }
}