using System.Text;

string SerializeAndDeserialize(string s)
{
    var serialized = Encoding.UTF8.GetBytes(s);
    return Encoding.UTF8.GetString(serialized);
}

const string stringRU = "Это тестовая строка на русском языке.";
const string stringDE = "Dies ist ein Teststring in Deutsch.";
const string stringJP = "これは日本語のテスト文字列です。";

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine(SerializeAndDeserialize(stringRU));
Console.WriteLine(SerializeAndDeserialize(stringRU) == stringRU);

Console.WriteLine(SerializeAndDeserialize(stringDE));
Console.WriteLine(SerializeAndDeserialize(stringDE) == stringDE);

Console.WriteLine(SerializeAndDeserialize(stringJP));
Console.WriteLine(SerializeAndDeserialize(stringJP) == stringJP);