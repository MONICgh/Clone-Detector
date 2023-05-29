using NUnit.Framework;

namespace Password
{
    internal class PasswordTest
    {
        [Test]
        public void Test1()
        {
            string password = Password.GeneratePassword();
            Assert.IsTrue(6 <= password.Length && password.Length <= 20);
            Assert.IsTrue(password.Count(x => x == '_') == 1);
            Assert.IsTrue(password.Count(char.IsUpper) >= 2);
            Assert.IsTrue(password.Count(char.IsDigit) <= 5);

            for (int i = 0; i < password.Length - 1; i++)
            {
                Assert.IsTrue(!char.IsDigit(password[i]) || !char.IsDigit(password[i + 1]));
            }
        }

        [Test]
        public void Test2()
        {
            string password = Password.GeneratePassword();
            Assert.IsTrue(6 <= password.Length && password.Length <= 20);
            Assert.IsTrue(password.Count(x => x == '_') == 1);
            Assert.IsTrue(password.Count(char.IsUpper) >= 2);
            Assert.IsTrue(password.Count(char.IsDigit) <= 5);

            for (int i = 0; i < password.Length - 1; i++)
            {
                Assert.IsTrue(!char.IsDigit(password[i]) || !char.IsDigit(password[i + 1]));
            }
        }
    }
}
