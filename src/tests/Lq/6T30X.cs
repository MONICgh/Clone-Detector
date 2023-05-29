using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lab12
{
    [TestClass]
    public class AllergiesTest
    {
        [TestMethod]
        public void TestToString()
        {
            var mary = new Allergies("Mary");
            var joe = new Allergies("Joe", 65);
            var rob = new Allergies("Rob", "Peanuts Chocolate Cats Strawberries");

            string maryMessage = "Mary has no allergies!";
            string joeMessage = "Joe has allergies to eggs and pollen";
            string robMessage = "Rob has allergies to peanuts, strawberries, chocolate and cats";
            Assert.IsTrue(maryMessage.Equals(mary.ToString()));
            Assert.IsTrue(joeMessage.Equals(joe.ToString()));
            Assert.IsTrue(robMessage.Equals(rob.ToString()));
        }

        [TestMethod]
        public void TestIsAllergicTo()
        {
            var mary = new Allergies("Mary");
            var joe = new Allergies("Joe", 65);
            var rob = new Allergies("Rob", "Peanuts Chocolate Cats Strawberries");

            Assert.IsFalse(mary.IsAllergicTo(Allergies.Allergen.Eggs));
            Assert.IsFalse(mary.IsAllergicTo("Eggs"));
            Assert.IsTrue(joe.IsAllergicTo(Allergies.Allergen.Eggs));
            Assert.IsTrue(joe.IsAllergicTo("Eggs"));
            Assert.IsFalse(rob.IsAllergicTo(Allergies.Allergen.Eggs));
            Assert.IsFalse(rob.IsAllergicTo("Eggs"));
            Assert.IsTrue(rob.IsAllergicTo(Allergies.Allergen.Peanuts));
            Assert.IsTrue(rob.IsAllergicTo("Peanuts"));
            Assert.IsTrue(rob.IsAllergicTo(Allergies.Allergen.Chocolate));
            Assert.IsTrue(rob.IsAllergicTo("Chocolate"));
            Assert.IsFalse(joe.IsAllergicTo(Allergies.Allergen.Cats));
            Assert.IsFalse(joe.IsAllergicTo("Cats"));
        }

        [TestMethod]
        public void TestAddDeleteAllergy()
        {
            var mary = new Allergies("Mary");

            Assert.IsFalse(mary.IsAllergicTo(Allergies.Allergen.Eggs));
            mary.AddAllergy("Eggs");
            Assert.IsTrue(mary.IsAllergicTo(Allergies.Allergen.Eggs));
            mary.DeleteAllergy(Allergies.Allergen.Eggs);
            Assert.IsFalse(mary.IsAllergicTo(Allergies.Allergen.Eggs));
            mary.AddAllergy(Allergies.Allergen.Eggs);
            Assert.IsTrue(mary.IsAllergicTo(Allergies.Allergen.Eggs));
            mary.DeleteAllergy("Eggs");
            Assert.IsFalse(mary.IsAllergicTo(Allergies.Allergen.Eggs));

        }
    }
}
