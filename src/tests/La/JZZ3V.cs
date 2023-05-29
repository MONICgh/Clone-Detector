namespace ClassAttributes;

[AttributeUsage(AttributeTargets.All)]
public class Custom : Attribute
{
    public string Author { get; }
    public int RevisionNumber { get; }
    public string Description { get; }
    public string[] Reviewers { get; }

    public Custom(string author, int revisionNumber, string description, params string[] reviewers)
    {
        Author = author;
        RevisionNumber = revisionNumber;
        Description = description;
        Reviewers = reviewers;
    }
}