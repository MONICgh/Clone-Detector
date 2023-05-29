using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lab8
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] phrases = { "But I refuse.", "Но я отказываюсь.", "だが断る。" };
            byte[][] bytes = new byte[3][];
            for (int i = 0; i < phrases.Length; ++i)
                bytes[i] = Serializer.Serialize(phrases[i]);

            string[] expected = { "42-75-74-20-49-20-72-65-66-75-73-65-2E",
                                   "D0-9D-D0-BE-20-D1-8F-20-D0-BE-D1-82-D0-BA-D0-B0-D0-B7-D1-8B-D0-B2-D0-B0-D1-8E-D1-81-D1-8C-2E",
                                   "E3-81-A0-E3-81-8C-E6-96-AD-E3-82-8B-E3-80-82" };
            for (int i = 0; i < expected.Length; ++i)
                Assert.IsTrue(expected[i].Equals(System.BitConverter.ToString(bytes[i])));

            for (int i = 0; i < phrases.Length; ++i)
                Assert.IsTrue(phrases[i].Equals(Serializer.Deserialize(bytes[i])));
        }
        [TestMethod]
        public void TestMethod2()
        {
            LateExceptionThrower lateExceptionThrower = new LateExceptionThrower();

            try
            {
                lateExceptionThrower.DoSomethingStupid();
            }
            catch (DivideByZeroException)
            {
                Assert.Fail();
            }

            try
            {
                lateExceptionThrower.ThrowYourProblemsAtMe();
                Assert.Fail();
            }
            catch (DivideByZeroException)
            { }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestMethod3()
        {
            string[] input = { "eA2a1E", "Re4r", "6jnM31Q", "846ZIbo" };
            string[] expected = { "aAeE12", "erR4", "jMnQ136", "bIoZ468" };
            for (int i = 0; i < input.Length; ++i)
            {
                Assert.IsTrue(expected[i].Equals(StringSorter.Sort(input[i])));
            }
        }
    }
}
