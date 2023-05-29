using NUnit.Framework;

namespace HW_11;

[TestFixture]
public class PermutationTests
{
    [Test]
    public void SimpleTest()
    {
        Assert.AreEqual(Permutations.Permutations.GetNextPermutation("ABC"), "ACB");
        Assert.AreEqual(Permutations.Permutations.GetNextPermutation("ACB"), "BAC");
        Assert.AreEqual(Permutations.Permutations.GetNextPermutation("CBA"), null);
    }

    [Test]
    public void Generate()
    {
        Assert.AreEqual(Permutations.Permutations.GenerateLine("AB"), "AB BA");
    }
}
