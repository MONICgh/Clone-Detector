using System.Text;
using static Allergic.Allergies;

namespace Allergic
{
    class Allergies
    {
        public string Name { get; private set; }
        public int Score { get; private set; }
        public enum Allergen
        {
            Eggs = 1,
            Peanuts = 2,
            Shellfish = 4,
            Strawberries = 8,
            Tomatos = 16,
            Chocolate = 32,
            Pollen = 64,
            Cats = 128
        }

        public Allergies(string name, int score = 0)
        {
            Name = name;
            Score = score;
        }

        public Allergies(string name, string allergies)
        {
            Name = name;
            var allerg = allergies.Split(" ");
            Score = 0;
            foreach (var allergen in allerg)
            {
                var i = (Allergen)Enum.Parse(typeof(Allergen), allergen);
                Score += (int)i;
            }
        }

        public override string ToString()
        {
            var ans = new StringBuilder($"{Name} ");
            if (Score == 0)
            {
                ans.Append("has no allergy!");
            }
            else
            {
                ans.Append("is allergic to ");
                foreach (var allergen in Enum.GetValues(typeof(Allergen)))
                {
                    if (IsAllergicTo((Allergen)allergen))
                    {
                        ans.Append($"{allergen.ToString()}, ");
                    }
                }
                ans.Remove(ans.Length - 2, 2);
            }
            return ans.ToString();
        }

        public bool IsAllergicTo(Allergen allergen)
        {
            return (Score % ((int)allergen * 2) >= (int)allergen) ? true : false;
        }

        public bool IsAllergicTo(string allergen)
        {
            return IsAllergicTo((Allergen)Enum.Parse(typeof(Allergen), allergen));
        }

        public void AddAllergy(Allergen allergen)
        {
            if (!IsAllergicTo(allergen))
            {
                Score += (int)allergen;
            }
        }

        public void AddAllergy(string allergen)
        {
            AddAllergy((Allergen)Enum.Parse(typeof(Allergen), allergen));
        }

        public void DeleteAllergy(Allergen allergen)
        {
            if (IsAllergicTo(allergen))
            {
                Score -= (int)allergen;
            }
        }

        public void DeleteAllergy(string allergen)
        {
            DeleteAllergy((Allergen)Enum.Parse(typeof(Allergen), allergen));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var mary = new Allergies("Mary");
            var joe = new Allergies("Joe", 65);
            var rob = new Allergies("Rob", "Peanuts Chocolate Cats Strawberries");

            Console.WriteLine(mary);
            Console.WriteLine(joe);
            Console.WriteLine(rob);
            Console.WriteLine();

            Console.WriteLine(mary.Name);
            Console.WriteLine(joe.Score);
            Console.WriteLine();

            Console.WriteLine(joe.IsAllergicTo(Allergen.Cats));
            Console.WriteLine(rob.IsAllergicTo("Peanuts"));
            Console.WriteLine();

            joe.AddAllergy("Cats");
            mary.AddAllergy(Allergen.Chocolate);

            Console.WriteLine(mary);
            Console.WriteLine(joe);
            Console.WriteLine(rob);
            Console.WriteLine();

            joe.DeleteAllergy("Cats");
            rob.DeleteAllergy(Allergen.Chocolate);

            Console.WriteLine(mary);
            Console.WriteLine(joe);
            Console.WriteLine(rob);
            Console.WriteLine();
        }


    }
}
