using System;

namespace Interfaces;

interface IProd
{
    int Operation(int first, int second);
}

interface IPow
{
    int Operation(int first, int second);
}

public abstract class MyAbstractClass
{
    public abstract int Operation(int first, int second);
}

public class SumClass : MyAbstractClass, IProd, IPow
{
    public override int Operation(int first, int second)
    {
        return first + second;
    }

    int IPow.Operation(int first, int second)
    {
        return (int)Math.Pow(first, second);
    }
    
    int IProd.Operation(int first, int second)
    {
        return first * second;
    }
}