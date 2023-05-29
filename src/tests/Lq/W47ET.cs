using NUnit.Framework;

namespace HW_12.allergy;

[TestFixture]
public class Test
{
    [Test]
    public void TestAllergies()
    {
        var mary = new Allergies("mary", new List<Allergy> { Allergy.Cats, Allergy.Chocolate });
        Assert.AreEqual("mary has chocolate, cats allergies", mary.ToString());
    }
}
