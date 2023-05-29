using System;
using System.Collections.Generic;
using System.Linq;

namespace PalindromeSequence;

public class PalindromeSequenceClass
{
    private Dictionary<long,Tuple<long,long>> LruCache = new();
    private static long Invert(long value)
    {
        long reverse = 0;
        while(value != 0)      
        {      
            var rem = value % 10;        
            reverse = reverse *10 + rem;      
            value /= 10;      
        }

        return reverse;
        // return long.Parse(string.Join("", value.ToString().ToCharArray().Reverse()));
    }

    private static long PalindromeStep(long value)
    {
        return value + Invert(value);
    }

    public Tuple<long, long> PalSeq(long palindrome)
    {
        var possibleParents = new List<Tuple<long, long>> { Tuple.Create(palindrome, (long)0) };
        var length = palindrome.ToString().Length;
        for (long possibleSeed = (long)Math.Pow(10, Math.Max(length - 2, 0)); possibleSeed < palindrome; possibleSeed++)
        {
            if (PalindromeStep(possibleSeed) == palindrome)
            {
                var (seed, steps) = LruCache.ContainsKey(possibleSeed) ? LruCache[possibleSeed] : PalSeq(possibleSeed);
                possibleParents.Add(Tuple.Create(seed, steps + 1));
            }
        } 
        var result = possibleParents.MinBy(parent => parent.Item1)!;
        LruCache[palindrome] = result;
        return result;
    }
}