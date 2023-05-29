namespace Password
{
    public static class Password
    {
        public static string GeneratePassword()
        {
            string withDigit = "";
            string withoutDigit = "";
            for (char c = 'A'; c <= 'Z'; c++)
            {
                withDigit += c;
                withoutDigit += c;
            }
            for (char c = 'a'; c <= 'z'; c++)
            {
                withDigit += c;
                withoutDigit += c;
            }
            for (char c = '0'; c <= '9'; c++)
            {
                withDigit += c;
            }

            Random rnd = new Random();
            int len = rnd.Next(6, 21);
            char[] password = new char[len];
            
            int pos_ = rnd.Next(0, len);
            password[pos_] = '_';

            int posA = rnd.Next(0, len);
            while (posA == pos_)
            {
                posA = rnd.Next(0, len);
            }
            password[posA] = (char)(rnd.Next(0, 26) + 'A');

            int posB = rnd.Next(0, len);
            while (posB == posA || posB == pos_)
            {
                posB = rnd.Next(0, len);
            }
            password[posB] = (char)(rnd.Next(0, 26) + 'A');

            int digit = 0;
            for (int i = 0; i < len; i++)
            {
                if (i == pos_ || i == posA || i == posB)
                {
                    continue;
                }
                if (digit < 5 && (i == 0 || !char.IsDigit(password[i - 1])))
                {
                    int pos = rnd.Next(0, withDigit.Length);
                    password[i] = withDigit[pos];
                    if (char.IsDigit(password[i]))
                    {
                        digit++;
                    }
                }
                else
                {
                    int pos = rnd.Next(0, withoutDigit.Length);
                    password[i] = withoutDigit[pos];
                }
            }
            return new string(password);
        }
    }
}