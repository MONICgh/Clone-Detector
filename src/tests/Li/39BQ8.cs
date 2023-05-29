using System.Runtime.Serialization.Formatters.Binary;

namespace Serializer
{
    public class Serializer
    {
        public static byte[] Serialize(string s)
        {
            BinaryFormatter formatter = new();
            using (MemoryStream ms = new())
            {
                formatter.Serialize(ms, s);
                return ms.ToArray();
            }
        }

        public static string Deserialize(byte[] bytes)
        {
            BinaryFormatter formatter = new();
            using (MemoryStream ms = new(bytes))
            {
                return (string) formatter.Deserialize(ms);
            }
        }
    }
}