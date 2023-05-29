using Xunit;

namespace Dice;

public static class DiceTest
{
    public static void DoTest()
    {
        Assert.Equal(5, Dice.DiceRoll(2, 6));
        Assert.Equal(1, Dice.DiceRoll(2, 2));
        Assert.Equal(1, Dice.DiceRoll(1, 3));
        Assert.Equal(4, Dice.DiceRoll(2, 5));
        Assert.Equal(3, Dice.DiceRoll(3, 4));
        Assert.Equal(80, Dice.DiceRoll(4, 18));
        Assert.Equal(4221, Dice.DiceRoll(6, 20));
    }
}