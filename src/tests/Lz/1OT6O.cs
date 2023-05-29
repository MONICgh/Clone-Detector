using System;
using System.Text;

namespace EventBusLib
{
    public interface IPublisher
    {
        void Post(string message);
        event Action<string> OnPost;
        string Username();
    }

    public class Publisher : IPublisher
    {
        public event Action<string> OnPost = delegate { };
        private string _username;

        public Publisher(string name)
        {
            _username = name;
        }

        public void Post(string message)
        {
            var post = new StringBuilder();
            post.Append(_username);
            post.Append(" - ");
            post.Append(message);
            OnPost.Invoke(post.ToString());
        }

        public string Username()
        {
            return _username;
        }
    }
}