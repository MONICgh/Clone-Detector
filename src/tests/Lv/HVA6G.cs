namespace Concat
{
    public interface IName
    {
        public string Name();
    }

    static public class Concat
    {
        static public string Concatenate<T>(IEnumerable<T> sequence, char delimeter)
            where T : IName
        {
            return sequence.Skip(3).Select(x => x.Name()).Aggregate((concatStr, curStr) => concatStr + delimeter + curStr);
        }
    }
}