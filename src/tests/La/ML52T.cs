namespace EnvelopesTask;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var envelopes = new List<Envelope>
        {
            new Envelope(5, 4),
            new Envelope(4, 6),
            new Envelope(6, 7),
            new Envelope(2, 3),
        };
        var actual = Solution.FindSolution(envelopes);
        Assert.AreEqual(3, actual);
    }
    
    [Test]
    public void Test2()
    {
        var envelopes = new List<Envelope>
        {
            new Envelope(1, 1),
            new Envelope(1, 1),
            new Envelope(1, 1),
        };
        var actual = Solution.FindSolution(envelopes);
        Assert.AreEqual(1, actual);
    }
}