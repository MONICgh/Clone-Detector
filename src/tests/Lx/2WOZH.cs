using System.Security.Cryptography;

namespace Task2;

static class PasswordGenerator
{
    public static string Generate()
    {
        // Length of password
        var size = RandomNumberGenerator.GetInt32(6, 21);
        // Number of digits 
        var digits = RandomNumberGenerator.GetInt32(Math.Min((size + 1) / 2, 5));
        // Number of capital letters
        var capitals = RandomNumberGenerator.GetInt32(2, size - 1 - digits);
        
        LinkedList<char> nonNumbers = new LinkedList<char>();

        nonNumbers.AddLast('_');
        for (var i = 0; i < capitals; i++)
        {
            nonNumbers.AddLast((char)RandomNumberGenerator.GetInt32('A', 'Z'));
        }

        for (var i = 0; i < size - digits - capitals - 1; i++)
        {
            nonNumbers.AddLast((char)RandomNumberGenerator.GetInt32('a', 'z'));
        }

        var password = "";
        var prevNumber = false;
        
        // Generating cycle
        for (var i = 0; i < size; i++) 
        {
            if (!prevNumber && digits > 0 && ((size - i + 1) / 2 == digits || RandomNumberGenerator.GetInt32(2) == 1))
            {
                password += (char)RandomNumberGenerator.GetInt32('0', '9' + 1);
                prevNumber = true;
                digits--;
            }
            else
            {
                var ind = RandomNumberGenerator.GetInt32(nonNumbers.Count);
                var next = nonNumbers.ElementAt(ind);
                password += next;
                nonNumbers.Remove(next);
                prevNumber = false;
            }
        }

        return password;
    }
}