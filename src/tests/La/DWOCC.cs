using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Application
{
    sealed class CustomAttribute : Attribute
    {
        public string Author;
        public int RevisionNumber;
        public string Description;
        public string[] Reviewers;
        public CustomAttribute(string author, int revisionNumber, string description, params string[] reviewers)
        {
            Author = author;
            RevisionNumber = revisionNumber;
            Description = description;
            Reviewers = reviewers;
        }
    }

    [Custom("Joe", 2, "Class to work with health data.", "Arnold", "Bernard")]
    public class HealthScore
    {
        [Custom("Andrew", 3, "Method to collect health data.", "Sam", "Alex")]
        public static long CalcScoreData()
        {
            return 1;
        }

        [Custom("Andrew", 1, "Just method", "Alex")]
        public void Func()
        {

        }

        public void Func2()
        {

        }
    }

    class Task2
    {
        static void ShowAttributes(MemberInfo memberInfo)
        {
            var attribute = memberInfo.GetCustomAttribute<CustomAttribute>();
            if (attribute != null)
            {
                Console.WriteLine($"{memberInfo} CustomAttribute: Author={attribute.Author}; RevisionNumber={attribute.RevisionNumber}; " +
                    $"Description={attribute.Description}; Reviewers=[{String.Join(", ", attribute.Reviewers)}]");
            }
            else
            {
                Console.WriteLine($"{memberInfo} has no CustomAttribute");
            }
        }

        static void Main()
        {
            Type healthScore = Type.GetType("Application.HealthScore");
            MemberInfo healthScoreInfo = healthScore.GetTypeInfo();
            ShowAttributes(healthScoreInfo);
            foreach (MemberInfo methodInfo in healthScore.GetMethods())
            {
                ShowAttributes(methodInfo);
            }
        }
    }
}
