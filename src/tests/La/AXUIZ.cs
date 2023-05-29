namespace Task2;

public class Custom: Attribute
{
    public string Author { get; }
    public int Revision { get; }
    public string Description { get; }
    public string[] Reviewers { get; }
    
    public Custom(string author, int revision, string description, params string[] reviewers)
    {
        Author = author;
        Revision = revision;
        Description = description;
        Reviewers = reviewers;
    }

    public override string ToString()
    {
        return "Custom(" + Author + ", " + Revision + ", " + Description + ", [" + string.Join(", ", Reviewers) + "])";
    }
}