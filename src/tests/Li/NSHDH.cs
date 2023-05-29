using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Text;

namespace Homework8;

public static class Tasks
{
    // Task 1: string serializing

    public static byte[] serializeString(string str)
    {
        return Encoding.Unicode.GetBytes(str);
    }

    public static string deserializeString(byte[] encodedStr)
    {
        return Encoding.Unicode.GetString(encodedStr);
    }

    // Task 2: ExceptionDispatchInfo

    public static void exceptionDispatcherInfo()
    {
        try
        {
            ExceptionDispatchInfo dispatchInfo = ExceptionDispatchInfo.Capture(new ArithmeticException());
            makeException(dispatchInfo);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex);
        }
    }

    private static void makeException(ExceptionDispatchInfo dispatchInfo)
    {
        dispatchInfo.Throw();
    }
    
    // Task 3: string comparator

    public static bool compareStrings(string a, string b)
    {
        if (Math.Abs(a.Length - b.Length) > 1)
        {
            return false;
        }

        if (a.Length == b.Length)
        {
            int diffCounter = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    diffCounter++;
                }
            }

            return diffCounter == 1;
        }

        if (a.Length < b.Length)
        {
            (a, b) = (b, a);
        }
        
        int diffStatus = 0;
        for (int i = 0; i+diffStatus < a.Length && i < b.Length; i++)
        {
            if (a[i+diffStatus] != b[i])
            {
                if (diffStatus > 0)
                {
                    return false;
                }

                diffStatus++;
            }
        }

        return diffStatus <= 1;
    }
    
    // Task 4: merge strings

    private static Tuple<int, int>? findFirstEqualWord(string[] wordsA, string[] wordsB, int indexA, int indexB)
    {
        for (int i = 0; i < wordsA.Length - indexA; i++)
        {
            for (int j = i; j < wordsB.Length - indexB; j++)
            {
                if (wordsA[i+indexA] == wordsB[j+indexB])
                {
                    return new Tuple<int, int>(i, j);
                }
            }
        }

        return null;
    }

    public static string mergeStrings(string a, string b)
    {
        var wordsA = a.Split(" ");
        var wordsB = b.Split(" ");
        var indexA = 0;
        var indexB = 0;
        var mergeWords = new List<string>();

        while (indexA < wordsA.Length && indexB < wordsB.Length)
        {
            if (wordsA[indexA] == wordsB[indexB])
            {
                mergeWords.Add(wordsA[indexA]);
                indexA++;
                indexB++;
            }
            else
            {
                var nextPairOrNull = findFirstEqualWord(wordsA, wordsB, indexA, indexB);
                if (nextPairOrNull is null)
                {
                    mergeWords.AddRange(wordsA.Skip(indexA));
                    mergeWords.AddRange(wordsB.Skip(indexB));
                    break;
                }

                var (nextA, nextB) = nextPairOrNull;
                mergeWords.AddRange(wordsA.Skip(indexA).Take(nextA));
                mergeWords.AddRange(wordsB.Skip(indexB).Take(nextB));
                indexA += nextA;
                indexB += nextB;
            }
        }

        return string.Join(" ", mergeWords);
    }
    
    // Task 5: string sorting
    
    private static int getOrder(char c)
    {
        if (char.IsLower(c))
        {
            return 2 * (c - 'a');
        }

        if (char.IsUpper(c))
        {
            return 2 * (c - 'A') + 1;
        }

        if (char.IsDigit(c))
        {
            return c - '0' + 52;
        }

        throw new ArgumentException($"Invalid char: {c}");
    }

    public static string sortString(string str)
    {

        return string.Join(
            "",
            str
                .ToCharArray()
                .OrderBy(getOrder)
        );
    }
    
    // Task 5: stringify Fibonacci
    public static string stringifyFib(int n)
    {
        if (n < 2)
        {
            return "invalid";
        }
        
        var fibs = new List<string> {"b", "a"};

        while (n > 2)
        {
            fibs.Add(fibs.Last() + fibs.TakeLast(2).First());
            n--;
        }

        return string.Join(", ", fibs);
    }
}