using System.Collections;

namespace Allergies;

public class Allergies
{
    public string Name { get; }
    public int Score { get; set; }
    
    private List<Allergen> _allergens {get
    {
        var allergens = new List<Allergen>();
        var score = (Allergen)Score;
        foreach (Allergen allergen in Enum.GetValues(typeof(Allergen)))
        {
            if (score.HasFlag(allergen) && allergen != Allergen.Empty)
            {
                allergens.Add(allergen);
            }    
        }
        return allergens;
    }}

    public Allergies(string name, int score = 0)
    {
        Name = name;
        Score = score;
    }

    public Allergies(string name, string allergens)
    {
        Name = name;
        Score = allergens
            .Split(" ")
            .Select(nameToAllergen)
            .Sum(it => (int)it);
    }

    private static Allergen nameToAllergen(string name)
    {
        return Enum.TryParse(name, out Allergen a) ? a : Allergen.Empty;
    }

    public override string ToString()
    {
        return _allergens.Count switch
        {
            0 => $"{Name} does not have allergy!",
            1 => $"{Name} is allergic to {_allergens.First()}.",
            _ => $"{Name} is allergic to {string.Join(", ", _allergens.SkipLast(1))} and {_allergens.Last()}."
        };
    }

    public bool IsAllergicTo(string allergen)
    {
        return IsAllergicTo(nameToAllergen(allergen));
    }
    
    public bool IsAllergicTo(Allergen allergen)
    {
        return _allergens.Contains(allergen);
    }

    public void AddAllergy(string allergen)
    {
        AddAllergy(nameToAllergen(allergen));
    }
    
    public void AddAllergy(Allergen allergen)
    {
        Score += (int)allergen;
    }
    
    public void DeleteAllergy(string allergen)
    {
        DeleteAllergy(nameToAllergen(allergen));
    }
    
    public void DeleteAllergy(Allergen allergen)
    {
        Score -= (int)allergen;
    }
}