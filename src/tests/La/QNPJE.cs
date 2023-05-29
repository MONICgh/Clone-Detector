using System;

namespace Lab10
{
    [AttributeUsage(AttributeTargets.All)]
    class CustomAttribute : Attribute
    {
        string author;
        int revision_num;
        string description;
        string[] reviewers;
        public CustomAttribute(string author, int revision_num, string description, params string[] reviewers)
        {
            this.author = author;
            this.revision_num = revision_num;
            this.description = description;
            this.reviewers = reviewers;
        }

        public override string ToString()
        {
            return author + " " + revision_num.ToString()  + " " + description + " " + String.Join(" ", reviewers);
        }
    }
}
