namespace task1
{
    class Truck: Car
    {
        public static CarMaker<Truck> Create()
        {
            return new CarMaker<Truck>();
        }
        public override void GetDescription()
        {
            Console.WriteLine("Designed for the carriage of goods in the body or on a cargo platform");
        }
    }
}
