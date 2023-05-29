namespace task2
{
    class Program
    {
        public static void Test1()
        {
            var mary = new Allergies("Mary");
            Console.WriteLine(mary);
            Console.WriteLine(mary.IsAllergicTo(Allergies.Allergen.Cats)); //False
            Console.WriteLine(mary.Score); //0
            mary.AddAllergy(Allergies.Allergen.Cats);
            Console.WriteLine(mary.IsAllergicTo(Allergies.Allergen.Cats)); //True
            Console.WriteLine(mary.Score); //128
            mary.AddAllergy("Cats");
            Console.WriteLine(mary.Score); //128
            mary.DeleteAllergy("Shellfish");
            mary.DeleteAllergy(Allergies.Allergen.Cats);
            Console.WriteLine(mary.Score); //0
            Console.WriteLine("===Test1 finished===\n");
        }

        public static void Test2()
        {
            var joe = new Allergies("Joe", 65);
            Console.WriteLine(joe.IsAllergicTo(Allergies.Allergen.Eggs)); //True
            Console.WriteLine(joe.IsAllergicTo("Eggs")); //True
            Console.WriteLine(joe.IsAllergicTo("Tomatoes")); //False
            joe.DeleteAllergy("Eggs");
            Console.WriteLine(joe); //Joe is allergic to Pollen.
            Console.WriteLine(joe.Score); //64
            Console.WriteLine("===Test2 finished===\n");

        }

        public static void Test3()
        {
            var rob = new Allergies("Rob", "Peanuts Chocolate Cats Strawberries");
            Console.WriteLine(rob);
            Console.WriteLine(rob.Score);
            Console.WriteLine("===Test3 finished===\n");
        }
        public static void Main(string[] args)
        {

            Test1();
            Test2();
            Test3();
           
        }
    }
}