namespace task3
{
    class Program
    {
        public static void Simulate(string input)
        {
            var h2o = new H2O();
            var threads = new List<Thread>();
            foreach (char atom in input)
            {
                var thread = atom == 'H' ? new Thread(() => h2o.Hydrogen(() => Console.Write("H"))) : new Thread(() => h2o.Oxygen(() => Console.Write("O")));
                threads.Add(thread);
            }
            threads.ForEach(t => t.Start());
            threads.ForEach(t => t.Join());
            Console.WriteLine();
        }
        public static void Main(string[] args)
        {
            Simulate("HHO"); //HOH
            Simulate("OOHHHH");  //OHHOHH
         
        }
    }
}
