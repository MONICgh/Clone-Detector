using System.Text;

namespace task1
{
    class Program
    {
        static string CheckSerialization(string s, Encoding encoder)
        {
            Byte[] encodedString = encoder.GetBytes(s);
            string decodedString = encoder.GetString(encodedString);

            return decodedString;
        }
        static void Main(string[] args)
        {
            string russianString = "Привет!";
            Console.WriteLine(russianString == CheckSerialization(russianString, Encoding.UTF8)); //True

            string germanString = "Ich fahre nach Österreich";
            Console.WriteLine(germanString == CheckSerialization(germanString, Encoding.UTF8)); //True

            string japaneseString = "また近いうちにお会いしましょう";
            Console.WriteLine(japaneseString == CheckSerialization(japaneseString, Encoding.UTF8)); //True
        }
    }
}

