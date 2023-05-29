namespace TrackingAttributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Field)]
public class CustomAttribute : Attribute
{
    public string Author;
    public int Revision;
    public string Description;
    public string[] Reviewers;

    public CustomAttribute(string author, int revision, string description, params string[] reviewers)
    {
        Author = author;
        Revision = revision;
        Description = description;
        Reviewers = reviewers;
    }

    public override string ToString()
    {
        return Description + "\nrevision: " + Revision + "\nauthor: " + Author + "\nreviewers: " +
               String.Join(", ", Reviewers);
    }
}