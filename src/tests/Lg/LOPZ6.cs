namespace Application
{
    class Task3
    {
        static void Main()
        {
            var h2OGenerator = new H2OGenerator();
            var molecules = "HOH";
            h2OGenerator.Generate(molecules);
            Console.WriteLine();
            molecules = "OOHHHH";
            h2OGenerator.Generate(molecules);
        }
    }
}
