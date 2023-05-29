using HW02.DropTheDice;
using Xunit;

namespace UnitTests.DiceRollTests
{
    internal struct DiceRollQuery
    {
        public DiceRollQuery(int diceCount, int expectedSum, int expectedAnswer)
        {
            DiceCount = diceCount;
            ExpectedSum = expectedSum;
            ExpectedAnswer = expectedAnswer;
        }
        public int DiceCount { get; }
        public int ExpectedSum { get; }
        public int ExpectedAnswer { get; }
    }

    public class Tests
    {
        [Fact]
        public void CheckRolls()
        {
            // Arrange 
            var diceDropper = new DiceDropper();
            var requests = new[]
            {
                new DiceRollQuery(2, 6, 5),
                new DiceRollQuery(2, 2, 1),
                new DiceRollQuery(1, 3, 1),
                new DiceRollQuery(2, 5, 4),
                new DiceRollQuery(3, 4, 3),
                new DiceRollQuery(4, 18, 80),
                new DiceRollQuery(6, 20, 4221)
            };

            // Act & Assert
            foreach (var query in requests)
            {
                Assert.Equal(query.ExpectedAnswer, diceDropper.DiceRoll(query.DiceCount, query.ExpectedSum));
            }
        }
    }
}
