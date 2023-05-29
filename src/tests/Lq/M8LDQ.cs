namespace task1
{
    class PassengerCar: Car
    {
        public static CarMaker<PassengerCar> Create()
        {
            return new CarMaker<PassengerCar>();
        }
        public override void GetDescription()
        {
            Console.WriteLine("Designed to carry passengers and luggage, with a capacity of 2 to 8 people");
        }
    }
}
