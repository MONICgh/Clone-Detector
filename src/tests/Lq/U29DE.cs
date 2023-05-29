namespace Allergies;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var mary = new Allergies("Mary");
        Assert.AreEqual("Mary", mary.Name);
        Assert.AreEqual(0, mary.Score);
        Assert.AreEqual("Mary does not have allergy!", mary.ToString());
        Assert.IsFalse(mary.IsAllergicTo(Allergen.Cats));
        mary.AddAllergy("Cats");
        mary.AddAllergy(Allergen.Chocolate);
        Assert.IsTrue(mary.IsAllergicTo(Allergen.Cats));
        Assert.IsTrue(mary.IsAllergicTo("Chocolate"));
        mary.DeleteAllergy(Allergen.Chocolate);
        Assert.IsFalse(mary.IsAllergicTo("Chocolate"));
    }

    [Test]
    public void Test2()
    {
        var joe = new Allergies("Joe", 65);
        Assert.AreEqual("Joe is allergic to Eggs and FlowerPollen.", joe.ToString());
    }

    [Test]
    public void Test3()
    {
        var rob = new Allergies("Rob", "Peanut Chocolate Cats Strawberry");
        Assert.AreEqual("Rob", rob.Name);
        Assert.AreEqual("Rob is allergic to Peanut, Strawberry, Chocolate and Cats.", rob.ToString());
    }
}