using NUnit.Framework;

namespace HW_16;

[TestFixture]
public class H20Test
{
    [Test]
    public void TestH2O()
    {
        H2O h2O = new H2O();
        var res = h2O.Run("HHOOOO");
        foreach (var s in res.Split(" "))
        {
            var l = s.ToList();
            l.Sort();
            Assert.AreEqual(new List<char> { 'H', 'O', 'O' }, l);
        }
    }
}
