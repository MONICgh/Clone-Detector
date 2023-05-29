using System.Collections;
using System.Linq;
using System.Text;

namespace Application
{
    class Task1
    {
        static void Main()
        {
            var sentencies = new List<String>() { "Привет, мир!", "Hallo Welt!", "こんにちは世界" };
            Encoding encoding = Encoding.UTF8;
            foreach (string sentence in sentencies)
            {
                Byte[] bytes = encoding.GetBytes(sentence);
                var resentence = encoding.GetString(bytes);
                Console.WriteLine(resentence);
            }
        }
    }
}
