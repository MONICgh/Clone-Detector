namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<MyElement>{
                new MyElement("Anna"),
                new MyElement("Zhanna"),
                new MyElement("Snezhana"),
                new MyElement("Oil"),
                new MyElement("Coil"),
                new MyElement("Iron"),

            };
            MyElementMethods.IndexNameFilter(list).ForEach(elem => Console.Write(elem.Name + " ")); //Anna Zhanna Snezhana
        }
    }
}
