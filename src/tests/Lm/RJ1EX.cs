namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>
            {
                new Person("Anna", 42),
                new Person("Valya", 12),
                new Person("Mark", 27),
                new Person("anna", 16),
                new Person("Vika", 16),
            };

            people.Sort(new PersonNameComparer());
            Console.WriteLine("Sorted by name:");
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }

            Console.WriteLine();
            /*
             * Sorted by name:
                Anna, 42
                anna, 16
                Mark, 27
                Vika, 16
                Valya, 12
             */

            people.Sort(new PersonAgeComparer());
            Console.WriteLine("Sorted by age:");
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
            /*
             * Sorted by age:
                Valya, 12
                anna, 16
                Vika, 16
                Mark, 27
                Anna, 42
             */
            Console.WriteLine();
        }
    }
}
