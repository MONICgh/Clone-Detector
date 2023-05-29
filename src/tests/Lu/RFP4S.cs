using System.Text;

void FillFile(string filename, long n)
{
    const int digitsCnt = 8;
    const long upperBound = 100000000;
    const long a = 16769024;
    const long c = 9369319;

    if (n >= upperBound)
    {
        n = upperBound;
    }
    
    Stream outputStream = new FileStream(filename, FileMode.Create);

    long x = 0;

    for (long i = 0; i < n; i++)
    {
        x = (x * a + c) % upperBound;
        var numberString = x.ToString();
        numberString = new string('0', digitsCnt - numberString.Length) + numberString;

        outputStream.Write(Encoding.ASCII.GetBytes(numberString + '\n'));
    }
}

FillFile("sample.txt", 1000000000);
