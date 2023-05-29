using System.Runtime.CompilerServices;

namespace AllergiesTask;

public class Allergies
{
    public string Name { get; }
    public int Score { get; set; }

    public Allergies(string name)
    {
        Name = name;
        Score = 0;
    }

    public Allergies(string name, int mask)
    {
        Name = name;
        Score = mask;
    }

    public Allergies(string name, string allergies)
    {
        Name = name;
        Score = 0;
        foreach (var allergy in allergies.Split(' '))
        {
            Score |= (int)ToEnum(allergy);
        }
    }

    public override string ToString()
    {
        if (Score == 0)
        {
            return Name + " has no allergies";
        }
        var list = new List<Allergen>();
        for (var i = 1; i <= 128; i *= 2)
        {
            if ((Score & i) > 0)
            {
                list.Add((Allergen)i);
            }
        }

        return Name + " has " + string.Join(", ", list) + (list.Count > 1 ? " allergies" : " allergy");
    }

    public bool IsAllergicTo(string allergy)
    {
        return IsAllergicTo(ToEnum(allergy));
    }

    public bool IsAllergicTo(Allergen allergyEnum)
    {
        return (Score & (int)allergyEnum) > 0;
    }

    public void AddAllergy(string allergy)
    {
        AddAllergy(ToEnum(allergy));
    }

    public void AddAllergy(Allergen allergyEnum)
    {
        Score |= (int)allergyEnum;
    }

    public void DeleteAllergy(string allergy)
    {
        DeleteAllergy(ToEnum(allergy));
    }

    public void DeleteAllergy(Allergen allergyEnum)
    {
        if (IsAllergicTo(allergyEnum))
        {
            Score ^= (int)allergyEnum;
        }
    }

    private static Allergen ToEnum(string allergy)
    {
        return Enum.TryParse(allergy, true, out Allergen allergyEnum) ? allergyEnum : Allergen.Error;
    }
}