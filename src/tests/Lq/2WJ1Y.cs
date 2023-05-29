using static System.String;

namespace HW_12.allergy;

public class Allergies
{
    public string Name { get; }

    public int Score
    {
        get;
        set;
    }

    private readonly List<Allergy> _allergies;

    public Allergies(string name)
    {
        Name = name;
        _allergies = new List<Allergy>();
    }

    public Allergies(string name, List<Allergy> allergies)
    {
        Name = name;
        _allergies = allergies;
        _allergies.Sort();
        Score = allergies.Sum(it => (int)it);
    }

    public override string ToString()
    {
        if (_allergies.Count == 0)
        {
            return $"{Name} has no allergies";
        }
        var names = _allergies.Select(it => Enum.GetName(typeof(Allergy), it)!.ToLower());
        var join = Join(", ", names);
        return $"{Name} has {join} allergies";
    }

    private static Allergy? ParseAllergy(string name)
    {
        var tryParse = Enum.TryParse(
            name,
            out
            Allergy allergy);
        if (tryParse)
            return allergy;
        return null;
    }

    public bool IsAllergicTo(string name)
    {
        var allergy = ParseAllergy(name);
        return allergy != null && IsAllergicTo((Allergy)allergy);
    }

    public bool IsAllergicTo(Allergy allergy)
    {
        return _allergies.Contains(allergy);
    }

    public void AddAllergy(string name)
    {
        var allergy = ParseAllergy(name);
        if (allergy != null)
        {
            AddAllergy((Allergy)allergy);
        }
    }
    public void AddAllergy(Allergy allergy)
    {
        if (IsAllergicTo(allergy))
            return;
        _allergies.Add(allergy);
        Score += (int)allergy;
    }

    public void DeleteAllergy(string name)
    {
        var allergy = ParseAllergy(name);
        if (allergy != null)
        {
            DeleteAllergy((Allergy)allergy);
        }
    }

    public void DeleteAllergy(Allergy allergy)
    {
        if (_allergies.Remove(allergy))
            Score -= (int)allergy;
    }
}
