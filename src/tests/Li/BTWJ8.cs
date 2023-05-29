using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;

namespace Lab8
{
    public static class Serializer
    {
        public static byte[] Serialize(string s)
        {
            return Encoding.UTF8.GetBytes(s);
        }

        public static string Deserialize(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }
    }
    public class LateExceptionThrower
    {
        ExceptionDispatchInfo dispatchInfo;
        public void DoSomethingStupid()
        {
            try
            {
                int x = 0;
                int a = 7 / x;
            }
            catch(DivideByZeroException e)
            {
                dispatchInfo = ExceptionDispatchInfo.Capture(e);
            }
        }

        public void ThrowYourProblemsAtMe()
        {
            dispatchInfo?.Throw();
        }
    }

    public static class StringSorter
    {
        internal class Cmpr : Comparer<char>
        {
            public override int Compare(char x, char y)
            {
                if (Char.IsDigit(x))
                {
                    if (Char.IsDigit(y))
                        return x - y;
                    return 1;
                }
                if (Char.IsDigit(y))
                    return -1;

                // from there, x, y are both letters
                if (Char.ToLower(x) == Char.ToLower(y))
                {
                    return ('a' < 'A') ? x - y : y - x;
                }
                return Char.ToLower(x) - Char.ToLower(y);
            }
        }

        public static string Sort(string s)
        {
            char[] chars = s.ToCharArray();
            Array.Sort(chars, new Cmpr());
            return new string(chars);
        }
    }
}
