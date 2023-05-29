namespace StringPermutations;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("AB" , "AB BA")]
    [TestCase("CD" , "CD DC")]
    [TestCase("EF" , "EF FE")]
    [TestCase("NOT", "NOT NTO ONT OTN TNO TON")]
    [TestCase("RAM", "AMR ARM MAR MRA RAM RMA")]
    [TestCase("YAW", "AWY AYW WAY WYA YAW YWA")] 
    public void Test1(string chars, string expected)
    {
        Assert.AreEqual(expected, PermutationsClass.Permutations(chars));
    }
}