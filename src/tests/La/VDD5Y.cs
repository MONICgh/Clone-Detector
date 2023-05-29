namespace BlackBox
{
    public class Program
    {
        public static void Main()
        {
            WhiteBox wrapper = new();
            while (true)
            {
                string? s = Console.ReadLine();
                if (s == null)
                {
                    break;
                }

                bool do_action = false;
                if (s.StartsWith("Add(") && s.EndsWith(")"))
                {
                    wrapper.Add(int.Parse(s[4..(s.Length - 1)]));
                    wrapper.PrintCurrentValue();
                    do_action = true;
                }
                if (s.StartsWith("Subtract(") && s.EndsWith(")"))
                {
                    wrapper.Subtract(int.Parse(s[9..(s.Length - 1)]));
                    wrapper.PrintCurrentValue();
                    do_action = true;
                }
                if (s.StartsWith("Multiply(") && s.EndsWith(")"))
                {
                    wrapper.Multiply(int.Parse(s[9..(s.Length - 1)]));
                    wrapper.PrintCurrentValue();
                    do_action = true;
                }
                if (s.StartsWith("Divide(") && s.EndsWith(")"))
                {
                    wrapper.Divide(int.Parse(s[7..(s.Length - 1)]));
                    wrapper.PrintCurrentValue();
                    do_action = true;
                }
                if (!do_action)
                {
                    Console.WriteLine("Incorrect command: {0}", s); ;
                }
            }
        }
    }
}
