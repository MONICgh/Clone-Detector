namespace Application
{
    public enum Allergen
    {
        Eggs = 0,
        Peanut = 1,
        Shellfish = 2,
        Strawberry = 3,
        Tomatoes = 4,
        Chocolate = 5,
        Pollen = 6,
        Cats = 7
    }

    public class AllergenHelpers
    {
        public static Allergen fromString(string name)
        {
            switch (name)
            {
                case "Eggs":
                    return Allergen.Eggs;
                case "Peanut":
                    return Allergen.Peanut;
                case "Shellfish":
                    return Allergen.Shellfish;
                case "Strawberry":
                    return Allergen.Strawberry;
                case "Tomatoes":
                    return Allergen.Tomatoes;
                case "Chocolate":
                    return Allergen.Chocolate;
                case "Pollen":
                    return Allergen.Pollen;
                case "Cats":
                    return Allergen.Cats;
                default:
                    throw new Exception($"wrong allergen {name}");
            }
        }
    }

    class Allergies
    {
        private string name;
        private int allergensNum = 0;

        public string Name
        {
            get { return name; }
        }
        
        public int Score
        {
            get { return allergensNum; }
        }

        public Allergies(string name, int allergensNum = 0)
        {
            this.name = name;
            this.allergensNum = allergensNum;
        }
        
        public Allergies(string name, string Allergens)
        {
            this.name = name;
            this.allergensNum = Allergens.Split(' ').Select(x => 1 << (int)AllergenHelpers.fromString(x)).Sum();
        }

        public override string ToString()
        {
            var allergens = new List<string>();
            if (allergensNum == 0)
            {
                return $"{name} has no allergies!";
            }
            else
            {
                for (int i = 1, j = 0; i <=128; i *= 2, j++)
                {
                    if ((allergensNum & i) != 0)
                    {
                        allergens.Add(((Allergen)j).ToString());
                    }
                }
            }
            if (allergens.Count == 1)
            {
                return $"{name} is allergic to {allergens[0]}";
            }
            var lastAllergen = allergens.Last();
            allergens.RemoveAt(allergens.Count - 1);
            return $"{name} is allergic to {string.Join(", ", allergens)} and {lastAllergen}";
        }

        public bool IsAllergicTo(Allergen allergen)
        {
            int i = 1 << (int)allergen;
            return (allergensNum & i) != 0;
        }
        
        public bool IsAllergicTo(string allergen) => IsAllergicTo(AllergenHelpers.fromString(allergen));

        public void AddAllergy(Allergen allergen)
        {
            int i = 1 << (int)allergen;
            allergensNum = allergensNum | i;
        }
        
        public void AddAllergy(string allergen) => AddAllergy(AllergenHelpers.fromString(allergen));

        public void DeleteAllergy(Allergen allergen)
        {
            int i = 1 << (int)allergen;
            allergensNum = allergensNum & (255 - i);
        }
        
        public void DeleteAllergy(string allergen) => DeleteAllergy(AllergenHelpers.fromString(allergen));
    }
    
    class Task2
    {
        static void Main()
        {
            var mary = new Allergies("Mary");
            var joe = new Allergies("Joe", 65);
            var rob = new Allergies("Rob", "Peanut Chocolate Cats Strawberry");
            Console.WriteLine($"Name={mary.Name}, Score={mary.Score}");
            Console.WriteLine(mary);
            Console.WriteLine(joe);
            Console.WriteLine(rob);
            rob.AddAllergy(Allergen.Peanut);
            Console.WriteLine(rob);
            Console.WriteLine("mary.IsAllergicTo(Peanut)={0}", mary.IsAllergicTo("Peanut"));
            joe.DeleteAllergy("Eggs");
            Console.WriteLine(joe);
            Console.WriteLine("rob.IsAllergicTo(Peanut)={0}", rob.IsAllergicTo(Allergen.Peanut));
            rob.DeleteAllergy("Peanut");
            Console.WriteLine("rob.IsAllergicTo(Peanut)={0}", rob.IsAllergicTo(Allergen.Peanut));
            Console.WriteLine(rob);
            rob.AddAllergy(Allergen.Eggs);
            Console.WriteLine(rob);
        }
    }
}
