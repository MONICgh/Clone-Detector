using System;

namespace Allergies
{
    public class TestsAllergies
    {
        public void TestAll()
        {
            if (TestConstructor1() && TestConstructor2() && TestConstructor3() && TestAddAllergy() &&
                TestDeleteAllergy() && TestIsAllergicTo())
            {
                Console.WriteLine("Allergies: tests passed");
            }
            else
            {
                Console.WriteLine("Allergies: tests failed");
            }
        }
        
        public bool TestConstructor1()
        {
            var allergiesForPerson1 = new Allergies("John");
            if (allergiesForPerson1.Name != "John")
                return false;
            if (allergiesForPerson1.Score != 0)
                return false;
            string allergiesForPerson1AsString = allergiesForPerson1.ToString();
            if (allergiesForPerson1AsString != "John has no allergies.")
                return false;
            return true;
        }
        
        public bool TestConstructor2()
        {
            var allergiesForPerson1 = new Allergies("John", 10);
            if (allergiesForPerson1.Name != "John")
                return false;
            if (allergiesForPerson1.Score != 10)
                return false;
            string allergiesForPerson1AsString = allergiesForPerson1.ToString();
            if (allergiesForPerson1AsString != "John is allergic to Peanut and Strawberries.")
                return false;
            return true;
        }

        public bool TestConstructor3()
        {
            var allergiesForPerson1 = new Allergies("John", "Pollen Eggs Cats");
            if (allergiesForPerson1.Name != "John")
                return false;
            if (allergiesForPerson1.Score != 193)
                return false;
            string allergiesForPerson1AsString = allergiesForPerson1.ToString();
            if (allergiesForPerson1AsString != "John is allergic to Eggs, Pollen and Cats.")
                return false;
            return true;
        }

        public bool TestAddAllergy()
        {
            var allergiesForPerson1 = new Allergies("John", 10);
            allergiesForPerson1.AddAllergy("Pollen");
            if (allergiesForPerson1.Score != 74)
                return false;
            string allergiesForPerson1AsString = allergiesForPerson1.ToString();
            if (allergiesForPerson1AsString != "John is allergic to Peanut, Strawberries and Pollen.")
                return false;
            return true;
        }

        public bool TestDeleteAllergy()
        {
            var allergiesForPerson1 = new Allergies("John", 10);
            allergiesForPerson1.DeleteAllergy("Peanut");
            if (allergiesForPerson1.Score != 8)
                return false;
            string allergiesForPerson1AsString = allergiesForPerson1.ToString();
            if (allergiesForPerson1AsString != "John is allergic to Strawberries.")
                return false;
            return true;
        }

        public bool TestIsAllergicTo()
        {
            var allergiesForPerson1 = new Allergies("John", 10);
            if (allergiesForPerson1.IsAllergicTo("Peanut") == false)
                return false;
            if (allergiesForPerson1.IsAllergicTo("Cats"))
                return false;
            return true;
        }
    }
}