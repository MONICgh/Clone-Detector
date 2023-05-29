namespace CustomAttributeTask;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method)]  
public class Custom : Attribute
{
    public readonly string Author;
    public readonly int RevisionNumber;
    public readonly string Description;
    public readonly string[] Reviewers;


    public Custom(string author, int revisionNumber, string description, params string[] reviewers)
    {
        Author = author;
        RevisionNumber = revisionNumber;
        Description = description;
        Reviewers = reviewers;
    }
}
