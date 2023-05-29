using System.Diagnostics;
using System.Text;

byte[] Serialize(string s)
{
    return Encoding.UTF8.GetBytes(s);
}

string Deserialize(byte[] bytes)
{
    return Encoding.UTF8.GetString(bytes);
}

const string russian = "Привет, мир!";
const string german = "Hallo, Welt!";
const string japanese = "こんにちは、世界!";

Debug.Assert(Deserialize(Serialize(russian)).Equals(russian));
Debug.Assert(Deserialize(Serialize(german)).Equals(german));
Debug.Assert(Deserialize(Serialize(japanese)).Equals(japanese));

Console.WriteLine("All is Okay!");  