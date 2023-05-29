namespace task2
{
    class Program
    {
        private static Foo foo = new Foo();
        public static void Main(string[] args)
        {

            Console.Write("Threads order:");
            var input = Console.ReadLine();
            string[] parsedInput = input.Substring(1, input.Length - 2).Split(",");

            Thread A = new Thread(foo.first);
            Thread B = new Thread(foo.second);
            Thread C = new Thread(foo.third);

            foreach (string ind in parsedInput)
            {
                if (ind == "1")
                {
                    A.Start();
                }
                else if (ind == "2")
                {
                    B.Start();
                }
                else
                {
                    C.Start();
                }
            }

            A.Join();
            B.Join();
            C.Join();
            /*
             * Threads order:[1,2,3]
             * Output: firstsecondthird
             * 
             * Threads order:[1,3,2]
             * Output: firstsecondthird
             */
        }
    }

    }

