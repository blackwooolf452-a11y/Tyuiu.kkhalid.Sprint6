using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.Kkhalid.Sprint6.Task6.V14.Lib;
using System.IO;

namespace Tyuiu.Kkhalid.Sprint6.Task6.V14.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void SimpleTest1_FindWordsWithZ()
        {
            // Arrange
            DataService ds = new DataService();

            // ایجاد فایل تست ساده
            string testFile = "test1.txt";
            File.WriteAllText(testFile, "zoo cat dog zebra");

            try
            {
                // Act
                string result = ds.CollectTextFromFile(testFile);

                // Assert
                string expected = "zoo\r\nzebra";
                Assert.AreEqual(expected, result);
            }
            finally
            {
                // Cleanup
                if (File.Exists(testFile))
                    File.Delete(testFile);
            }
        }

        [TestMethod]
        public void SimpleTest2_NoWordsWithZ()
        {
            // Arrange
            DataService ds = new DataService();

            string testFile = "test2.txt";
            File.WriteAllText(testFile, "apple banana cherry");

            try
            {
                // Act
                string result = ds.CollectTextFromFile(testFile);

                // Assert
                Assert.AreEqual("", result);
            }
            finally
            {
                if (File.Exists(testFile))
                    File.Delete(testFile);
            }
        }

        [TestMethod]
        public void SimpleTest3_CaseInsensitive()
        {
            // Arrange
            DataService ds = new DataService();

            string testFile = "test3.txt";
            File.WriteAllText(testFile, "Zoo ZEBRA aZure haZard");

            try
            {
                // Act
                string result = ds.CollectTextFromFile(testFile);

                // Assert
                string expected = "Zoo\r\nZEBRA\r\naZure\r\nhaZard";
                Assert.AreEqual(expected, result);
            }
            finally
            {
                if (File.Exists(testFile))
                    File.Delete(testFile);
            }
        }

        [TestMethod]
        public void SimpleTest4_WithPunctuation()
        {
            // Arrange
            DataService ds = new DataService();

            string testFile = "test4.txt";
            File.WriteAllText(testFile, "amazing! puzzle, zero. (jazz)");

            try
            {
                // Act
                string result = ds.CollectTextFromFile(testFile);

                // Assert
                string expected = "amazing\r\npuzzle\r\nzero\r\njazz";
                Assert.AreEqual(expected, result);
            }
            finally
            {
                if (File.Exists(testFile))
                    File.Delete(testFile);
            }
        }

        [TestMethod]
        public void SimpleTest5_RealExample()
        {
            // Arrange
            DataService ds = new DataService();

            string testFile = "test5.txt";
            File.WriteAllText(testFile, @"This is a sample text.
It contains words like: zoo, amazing, puzzle.
Also ZEBRA and zero.
But not words like: cat, dog, house.");

            try
            {
                // Act
                string result = ds.CollectTextFromFile(testFile);

                // Assert
                string expected = "zoo\r\namazing\r\npuzzle\r\nZEBRA\r\nzero";
                Assert.AreEqual(expected, result);
            }
            finally
            {
                if (File.Exists(testFile))
                    File.Delete(testFile);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void SimpleTest6_FileNotFound()
        {
            // Arrange
            DataService ds = new DataService();

            // Act & Assert
            ds.CollectTextFromFile("non_existent_file.txt");
        }
    }
}