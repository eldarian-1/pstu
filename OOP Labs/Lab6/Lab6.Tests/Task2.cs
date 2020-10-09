using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab6.Tests
{
    [TestClass]
    public class Task2
    {
        private const string test
            = "hello world! меня зовут Эльдар. 453 564орпап алвпвалпр345  - helloh world меням зовут ЭльдарЭ Эльдарэ 4534 564орпап алвлпр345Ф";
        private const string result
            = "hello world! меня зовут Эльдар. 453 564орпап алвпвалпр345  -  world  зовут  Эльдарэ  564орпап алвлпр345Ф";

        [TestMethod]
        public void Test_Proccessing()
        {
            Assert.AreEqual(global::Task2.Program.Proccessing(test), result);
        }
    }
}
