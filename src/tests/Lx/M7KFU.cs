using System;
using System.Linq;
using System.Text;

namespace RandomPassword
{
    public class RandomPassword
    {
        private int length;
        private string password;

        public string getPassword()
        {
            return password;
        }

        public RandomPassword()
        {
            Random rnd = new Random();
            int len = rnd.Next(6, 20 + 1);
            length = len;
            password = getRandomPassword();
        }

        private string getRandomPassword()
        {
            const string Digits = "0123456789";
            const string LowerCase = "abcdefghijklmnopqrstuvwxyz";
            const string UpperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string Underscore = "_";

            var resultPassword = new StringBuilder(length);
            var rnd = new Random();

            int posOfUnderscore = rnd.Next(0, length);

            int posOfFirstUpperCase = rnd.Next(0, length);
            while (posOfFirstUpperCase == posOfUnderscore)
                posOfFirstUpperCase = rnd.Next(0, length);

            int posOfSecondUpperCase = rnd.Next(0, length);
            while (posOfSecondUpperCase == posOfUnderscore || posOfSecondUpperCase == posOfFirstUpperCase)
                posOfSecondUpperCase = rnd.Next(0, length);

            for (var i = 0; i < length; i++)
            {
                if (i == posOfUnderscore)
                {
                    resultPassword.Append(Underscore[0]);
                    continue;
                }

                if (i == posOfFirstUpperCase)
                {
                    const int numberOfLettersInAlphabet = 26;
                    var posNewSymbol = rnd.Next(0, numberOfLettersInAlphabet);
                    resultPassword.Append(UpperCase[posNewSymbol]);
                    continue;
                }

                if (i == posOfSecondUpperCase)
                {
                    const int numberOfLettersInAlphabet = 26;
                    var posNewSymbol = rnd.Next(0, numberOfLettersInAlphabet);
                    resultPassword.Append(UpperCase[posNewSymbol]);
                    continue;
                }

                if (i != 0 && resultPassword[i - 1].ToString().All(Char.IsDigit))
                {
                    const int numWithoutDigits = 53;
                    int posNewSymbol = rnd.Next(0, numWithoutDigits);
                    resultPassword.Append((LowerCase + UpperCase + Underscore)[posNewSymbol]);
                }
                else
                {
                    const int numWithDigits = 63;
                    int posNewSymbol = rnd.Next(0, numWithDigits);
                    resultPassword.Append((Digits + LowerCase + UpperCase + Underscore)[posNewSymbol]);
                }
            }

            return resultPassword.ToString();
        }
    }
}