using Microsoft.VisualStudio.TestTools.UnitTesting;
using global::Task1;

namespace Lab6.Tests
{
    [TestClass]
    public class Task1
    {
        private static int[][] array = new int[][]{
            new int[] { 23, 345, 789, 8, 0, 453, 0, 345, 0 },
            new int[] { 45, 45, 21, 5 },
            new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new int[] { 45, 0, 45, 21, 5 },
            new int[] { 45, 45, 21, 5 },
            new int[] { 0, 45, 21, 0 }
        };
        private readonly int[][] result = new int[][]{
            new int[] { 45, 45, 21, 5 },
            new int[] { 45, 0, 45, 21, 5 },
            new int[] { 45, 45, 21, 5 }
        };

        [TestMethod]
        public void Test_DeleteRows()
        {
            Program.DeleteRows(ref array);
            Assert.AreEqual(array.Length, result.Length);
            for(int i = 0, n = array.Length; i < n; ++i)
            {
                Assert.AreEqual(array[i].Length, result[i].Length);
                for (int j = 0, m = array[i].Length; j < m; ++j)
                    Assert.AreEqual(array[i][j], result[i][j]);
            }
        }
    }
}