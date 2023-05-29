namespace FindElem
{
    public interface IName
    {
        public string Name();
    }

    static public class FindElem
    {
        public static IEnumerable<T> Find<T>(IEnumerable<T> sequence) where T : IName
        {
            return sequence.Where((x, index) => x.Name().Length > index);
        }
    }
}