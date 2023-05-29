class Task2
{
    private static Random rnd = new Random();

    static string generatePassword()
    {
        string numbers = "0123456789";
        string bigSymbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string symbols = "abcdefghijklmnopqrstuvwxyz" + bigSymbols;
        string symbolsAll = symbols + numbers;

        int pass_length = rnd.Next(6, 21);
        var password = new char[pass_length];
        char symb1 = bigSymbols[rnd.Next(bigSymbols.Length)];
        char symb2 = bigSymbols[rnd.Next(bigSymbols.Length)];
        int place_under = rnd.Next(pass_length);
        int place_symb1 = rnd.Next(pass_length - 1);
        int place_symb2 = rnd.Next(pass_length - 2);
        place_symb1 += (place_under <= place_symb1) ? 1 : 0;
        place_symb2 += (Math.Min(place_under, place_symb1) <= place_symb2) ? 1 : 0;
        place_symb2 += (Math.Max(place_under, place_symb1) <= place_symb2) ? 1 : 0;
        var digits = 0;
        for (int i = 0; i < pass_length; i++)
        {
            if (i == place_under)
            {
                password[i] = '_';
            }
            else if(i == place_symb1)
            {
                password[i] = symb1;
            }
            else if (i == place_symb2)
            {
                password[i] = symb2;
            }
            else if ((i != 0 && char.IsDigit(password[i - 1])) || digits == 5)
            {
                password[i] = symbols[rnd.Next(symbols.Length)];
            }
            else
            {
                var ch = symbolsAll[rnd.Next(symbolsAll.Length)];
                if (char.IsDigit(ch)) digits++;
                password[i] = ch;
            }
        }
        return new string(password);
    }

    static int Main()
    {
        string pass = generatePassword();
        Console.WriteLine(pass);
        return 0;
    }
}
