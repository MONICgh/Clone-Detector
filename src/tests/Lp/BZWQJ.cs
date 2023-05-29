using NUnit.Framework;

namespace GeneratePermutations
{
    internal class PermutationTest
    {
        [Test]
        public void Test1()
        {
            Assert.IsTrue(Permutation.GenerateAllPermutations("AB") == "AB BA");
        }

        [Test]
        public void Test2()
        {
            Assert.IsTrue(Permutation.GenerateAllPermutations("CD") == "CD DC");
        }

        [Test]
        public void Test3()
        {
            Assert.IsTrue(Permutation.GenerateAllPermutations("EF") == "EF FE");
        }

        [Test]
        public void Test4()
        {
            Assert.IsTrue(Permutation.GenerateAllPermutations("NOT") == "NOT NTO ONT OTN TNO TON");
        }

        [Test]
        public void Test5()
        {
            Assert.IsTrue(Permutation.GenerateAllPermutations("RAM") == "AMR ARM MAR MRA RAM RMA");
        }

        [Test]
        public void Test6()
        {
            Assert.IsTrue(Permutation.GenerateAllPermutations("YAW") == "AWY AYW WAY WYA YAW YWA");
        }

        [Test]
        public void Test7()
        {
            Assert.IsTrue(Permutation.GenerateAllPermutations("AA") == "AA");
        }

        [Test]
        public void Test8()
        {
            Assert.IsTrue(Permutation.GenerateAllPermutations("ABAB") == "AABB ABAB ABBA BAAB BABA BBAA");
        }

    }
}
