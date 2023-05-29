namespace task1
{
     abstract class Car
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public CarBody Body { get; set; }
        public Chassis Chassis { get; set; }
        public Dashboard Dashboard { get; set; }
        public Engine Engine { get; set; }
        public Stereosystem Stereosystem { get; set; }
        public Transmission Transmission { get; set; }

        public virtual void GetDescription()
        {
            Console.WriteLine("Abstract car");
        }
    }
}
