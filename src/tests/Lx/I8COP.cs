using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;

namespace task2
{
    class PasswordGenerator
    {
        private Random rnd;
        private string password;

        private const string underscore = "_";
        private const string digits = "0123456789";
        private const string lowercaseAlphabet = "abcdefghijklmnopqrstuvwxyz";
        private const string uppercaseAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string specialSymbols = "!@#$%^&*()-=<>/.{}";

        public PasswordGenerator()
        {
            rnd = new Random();
            password = "";
        }
        private string RandomChoice(string collection, int count)
        {
            string selectedItems = "";
            for (int i = 0; i < count; i++)
            {
                int index = rnd.Next(0, collection.Length);
                selectedItems += collection[index];
            }
            return selectedItems;

        }
        public string GetPassword()
        {
            int passwordLength = rnd.Next(6, 21);

            int underscoreCount = 1;
            int uppercaseCount = rnd.Next(2, passwordLength - underscoreCount + 1);
            string uppercaseSlice = RandomChoice(uppercaseAlphabet, uppercaseCount);
            int lowercaseCount = rnd.Next(0, passwordLength - underscoreCount - uppercaseCount + 1);
            string lowercaseSlice = RandomChoice(lowercaseAlphabet, lowercaseCount);
            int digitsCount = rnd.Next(0, Math.Max(passwordLength - underscoreCount - uppercaseCount - lowercaseCount + 1, 6));
            int specialsCount = passwordLength - underscoreCount - uppercaseCount - lowercaseCount - digitsCount;
            string specialsSlice = RandomChoice(specialSymbols, specialsCount);

            password = uppercaseSlice + specialsSlice + underscore + lowercaseSlice;

            for (int i = 0; i < digitsCount; i+=2)
            {
                int index = rnd.Next(0, digits.Length);
                string digit = digits[index].ToString();
                password = password.Insert(i, digit);
            }
            return password;
        }
    }
}
