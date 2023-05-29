using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab12
{
    public class Allergies
    {
        [Flags]
        public enum Allergen
        {
            Eggs = 0b_0000_0001,
            Peanuts = 0b_0000_0010,
            Shellfish = 0b_0000_0100,
            Strawberries = 0b_0000_1000,
            Tomatoes = 0b_0001_0000,
            Chocolate = 0b_0010_0000,
            Pollen = 0b_0100_0000,
            Cats = 0b_1000_0000,
            None = 0
        }

        private static Allergen fromString(string s_allergen)
        {
            Allergen allergen = 0;
            string[] list = s_allergen.Split(" ");
            foreach (string s in list)
            {
                try
                {
                    allergen |= (Allergen)Enum.Parse(typeof(Allergen), s);
                }
                catch (ArgumentException)
                {
                    // ignore
                    Console.WriteLine("Warning: failed to parse name \"{0}\"; ignoring.", s);
                }
            }
            return allergen;
        }

        public string Name { get; private set; }
        public Allergen Score { get; private set; }

        public Allergies(string name, int score)
        {
            Name = name;
            Score = (Allergen)score;
        }
        public Allergies(string name) : this(name, 0) { }
        public Allergies(string name, String s_score) : this(name, (int)fromString(s_score)) { }

        public override string ToString()
        {
            Allergen score = (Allergen)Score;
            if (score == Allergen.None)
                return Name + " has no allergies!";
            
            List<string> allergies = new List<string>();
            foreach(Allergen allergen in Enum.GetValues(typeof(Allergen)))
            {
                if ((allergen & score) != 0)
                    allergies.Add(Enum.GetName(typeof(Allergen), allergen));
            }

            string manyAllergies = "";
            if (allergies.Count >= 2)
                manyAllergies = String.Join(", ", allergies.Take(allergies.Count - 1)).ToLower() + " and ";

            return Name + " has allergies to " + manyAllergies + allergies[allergies.Count - 1].ToLower();
        }

        public bool IsAllergicTo(Allergen allergen)
        {
            return (Score & allergen) != 0;
        }
        public bool IsAllergicTo(string s_allergen) 
        {
            return IsAllergicTo(fromString(s_allergen));

        }

        public void AddAllergy(Allergen allergen)
        {
            Score |= allergen;
        }
        public void AddAllergy(string s_allergen)
        {
            AddAllergy(fromString(s_allergen));
        }

        public void DeleteAllergy(Allergen allergen)
        {
            Score &= ~allergen;
        }
        public void DeleteAllergy(string allergen)
        {
            DeleteAllergy(fromString(allergen));
        }
    }
}
