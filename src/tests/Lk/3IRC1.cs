using System;
using System.Collections.Generic;

namespace HamsterSort;

public class HumsterGenerator
{
    private readonly Random _randomGenerator = new Random();
    
    public Hamster GenerateHamster()
    {
        List<String> woolTypes = new List<String>{"one", "two", "three"};
        const int maxHeight = 100;
        const int maxWeight = 50;
        const int maxAge = 10;
        
        Wool wool = new Wool(
            _randomGenerator.Next(0, (int)Math.Pow(2, 24)),
            woolTypes[_randomGenerator.Next(woolTypes.Count)]     
        );
        return new Hamster(
            wool,
            _randomGenerator.Next(maxWeight),
            _randomGenerator.Next(maxHeight),
            _randomGenerator.Next(maxAge)
        );
    }

    public List<Hamster> GenerateHamsterList(int length)
    {
        List<Hamster> result = new List<Hamster>();
        for (int i = 0; i < length; i++)
        {
            result.Add(GenerateHamster());
        }

        return result;
    }
}