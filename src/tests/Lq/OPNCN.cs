namespace Allergies;

public class Allergies
{
    public string Name { get; }

    public int Score { get; private set; }

    private List<Allergen> _allergens;

    public Allergies(string name)
    {
        Name = name;
        Score = 0;
        _allergens = new List<Allergen>();
    }

    public Allergies(string name, int score)
    {
        Name = name;
        Score = score;
        _allergens = AllergensFromScore(score);
    }

    public Allergies(string name, string allergens)
    {
        Name = name;
        _allergens = AllergensFromString(allergens);
        Score = CountScore(_allergens);
    }

    public override string ToString()
    {
        return _allergens.Count switch
        {
            0 => Name + " has no allergies!",
            1 => Name + " is allergic to " + _allergens.First() + ".",
            _ => Name + " is allergic to " + string.Join(", ", _allergens.Take(_allergens.Count - 1)) + " and " +
                 _allergens.Last() + "."
        };
    }

    public bool IsAllergicTo(Allergen allergen)
    {
        return _allergens.Contains(allergen);
    }

    public bool IsAllergicTo(string allergen)
    {
        return IsAllergicTo(AllergenFromString(allergen));
    }

    public void AddAllergy(Allergen allergen)
    {
        Score += (int)allergen;
        _allergens = AllergensFromScore(Score);
    }

    public void AddAllergy(string allergen)
    {
        AddAllergy(AllergenFromString(allergen));
    }

    public void DeleteAllergy(Allergen allergen)
    {
        if (!IsAllergicTo(allergen))
            return;
        Score -= (int)allergen;
        _allergens = AllergensFromScore(Score);
    }

    public void DeleteAllergy(string allergen)
    {
        DeleteAllergy(AllergenFromString(allergen));
    }

    private static List<Allergen> AllergensFromScore(int score)
    {
        var allergens = new List<Allergen>();
        for (var s = (int)Allergen.Cats; s > 0; s /= 2)
        {
            if (score < s)
                continue;
            allergens.Add((Allergen)s);
            score -= s;
        }

        allergens.Reverse();
        return allergens;
    }

    private static List<Allergen> AllergensFromString(string allergensString)
    {
        var allergens = allergensString.Split(" ").Select(s =>
        {
            Enum.TryParse(s, out Allergen allergen);
            return allergen;
        }).ToList();
        return AllergensFromScore(CountScore(allergens));
    }

    private static Allergen AllergenFromString(string allergenString)
    {
        return AllergensFromString(allergenString).Single();
    }

    private static int CountScore(List<Allergen> allergens)
    {
        return allergens.Sum(a => (int)a);
    }
}