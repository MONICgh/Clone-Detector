
using System.Linq;

namespace task2
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
            Tomatoes = 16,
            Chocolate = 32,
            Pollen = 64,
            Cats = 128
        }

        public Allergies(string name, int score = 0)
        {
            Name = name;
            Score = score;
        }

        public Allergies(string name, string inputAllergens)
        {
            Name = name;
            Score = 0;
            string[] allergens = inputAllergens.Split(" ");
            foreach (string allergen in allergens)
            {
                var allergenScore = (Allergen)Enum.Parse(typeof(Allergen), allergen);
                Score += (int)allergenScore;
            }
        }

        private List<Allergen> getAllergens()
        {
            var allergens = new List<Allergen>();
            int totalScore = Score;
            for (int allergyScore = 256; allergyScore > 0; allergyScore /= 2)
            {
                if (totalScore - allergyScore < 0)
                    continue;
                totalScore -= allergyScore;
                allergens.Add((Allergen)allergyScore);
            }
            return allergens;
        }

        public bool IsAllergicTo(Allergen allergen)
        {
            return getAllergens().Contains(allergen);
        }
        public bool IsAllergicTo(string allergen)
        {
            return IsAllergicTo((Allergen)Enum.Parse(typeof(Allergen), allergen));
        }
        public void AddAllergy(Allergen allergen)
        {
           if (!getAllergens().Contains(allergen))
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
            if (getAllergens().Contains(allergen))
            {
                Score -= (int)allergen;
            }
        }
        public void DeleteAllergy(string allergen)
        {
            DeleteAllergy((Allergen)Enum.Parse(typeof(Allergen), allergen));
        }

        public override string ToString()
        {
            if (Score == 0)
            {
                return $"{Name} has no allergy!";
            }
            else
            {
                string ans = "";
                foreach (var allergen in Enum.GetValues(typeof(Allergen)))
                {
                    if (IsAllergicTo((Allergen)allergen))
                    {
                        ans += $"{allergen.ToString()}, ";
                    }
                }
                ans = ans.Remove(ans.Length - 2, 2);
                return $"{Name} is allergic to " + ans + ".";
            }
        }


    }
}
