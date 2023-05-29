using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab13
{
    [TestClass]
    public class TestDeadlock
    {
        [TestMethod]
        public void TestMethod1()
        {
            Deadlock.Die();
        }
    }

    [TestClass]
    public class TestSudoku
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[,] i = new string[9, 9]  {{"5", "3", ".", ".", "7", ".", ".", ".", "."}
                                            ,{"6", ".", ".", "1", "9", "5", ".", ".", "."}
                                            ,{".", "9", "8", ".", ".", ".", ".", "6", "."}
                                            ,{"8", ".", ".", ".", "6", ".", ".", ".", "3"}
                                            ,{"4", ".", ".", "8", ".", "3", ".", ".", "1"}
                                            ,{"7", ".", ".", ".", "2", ".", ".", ".", "6"}
                                            ,{".", "6", ".", ".", ".", ".", "2", "8", "."}
                                            ,{".", ".", ".", "4", "1", "9", ".", ".", "5"}
                                            ,{".", ".", ".", ".", "8", ".", ".", "7", "9"}};
            var checker = new SudokuChecker(i);
            Assert.IsTrue(checker.Check());
        }
        [TestMethod]
        public void TestMethod2()
        {
            string[,] i = new string[9, 9]  {{"8", "3", ".", ".", "7", ".", ".", ".", "."}
                                            ,{"6", ".", ".", "1", "9", "5", ".", ".", "."}
                                            ,{".", "9", "8", ".", ".", ".", ".", "6", "."}
                                            ,{"8", ".", ".", ".", "6", ".", ".", ".", "3"}
                                            ,{"4", ".", ".", "8", ".", "3", ".", ".", "1"}
                                            ,{"7", ".", ".", ".", "2", ".", ".", ".", "6"}
                                            ,{".", "6", ".", ".", ".", ".", "2", "8", "."}
                                            ,{".", ".", ".", "4", "1", "9", ".", ".", "5"}
                                            ,{".", ".", ".", ".", "8", ".", ".", "7", "9"}};
            var checker = new SudokuChecker(i);
            Assert.IsFalse(checker.Check());
        }
    }
}
