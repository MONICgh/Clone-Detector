        static int GCD(int a, int b)
        {
            if (a < 0)
                a = -a;
            if (b < 0)
                b = -b;
            return b == 0 ? a : GCD(b, a % b);
        }

        string Simplify(string arg)
        {  
            string[] splitedArgs = arg.Split('/');
            if (splitedArgs.Length != 2)
            {
                throw new ArgumentException("Invalid input format");
            }
            if (splitedArgs[1] == "0")
            {
                throw new ArithmeticException("Invalid fraction: devision by zero");
            }

            try
            {
                int numerator = int.Parse(splitedArgs[0]);
                int denominator = int.Parse(splitedArgs[1]);
        
                
                int gcd = GCD(numerator, denominator);  
                numerator /= gcd;
                denominator /= gcd;
                if (denominator == 1)
                    {
                        return numerator.ToString();
                    }
                else
                    {
                        return numerator + "/" + denominator;

                    }   
            }
            catch
            {
                throw new ArgumentException("Arguments should be integer numbers");
            }
        }
        
       Console.WriteLine(Simplify("4/6")); // 2/3
       Console.WriteLine(Simplify("10/11")); // 10/11
       Console.WriteLine(Simplify("100/400")); // 1/4
       Console.WriteLine(Simplify("8/4")); // 2


