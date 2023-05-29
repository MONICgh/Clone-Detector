using System.Xml.Linq;

namespace Application
{
    class Task3
    {
        static private Int64 Gcd(Int64 x, Int64 y)
        {
            if (y == 0)
                return x;
            return Gcd(y, x % y);
        }

        static private string Simplify(string arg)
        {
            var a = arg.Split("/");
            if (a.Length != 2) throw new Exception("wrong fraction");
            var numerator = Convert.ToInt64(a[0]);
            var denominator = Convert.ToInt64(a[1]);
            var gcd = Gcd(numerator, denominator);
            if (denominator == gcd)
                return (numerator / gcd).ToString();
            return String.Format("{0}/{1}", numerator / gcd, denominator / gcd);
        }

        static int Main()
        {
            Console.WriteLine("Simplify({0}) = {1}", "4/6", Simplify("4/6"));
            Console.WriteLine("Simplify({0}) = {1}", "10/11", Simplify("10/11"));
            Console.WriteLine("Simplify({0}) = {1}", "100/400", Simplify("100/400"));
            Console.WriteLine("Simplify({0}) = {1}", "8/4", Simplify("8/4"));
            Console.WriteLine("Simplify({0}) = {1}", "4/8", Simplify("4/8"));
            Console.WriteLine("Simplify({0}) = {1}", "0/8", Simplify("0/8"));
            return 0;
        }
    }
}
