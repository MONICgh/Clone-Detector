namespace task1
{
    class Program
    { 
        public static void Main(string[] args)
        {
            Car passengerCar = MyFactory.CreateCar<PassengerCar>();
            Car truckCar = MyFactory.CreateCar<Truck>();
            var cars = new List<Car>() { passengerCar, truckCar };
            foreach (Car car in cars)
            {
                Console.WriteLine(car.GetType());
                car.GetDescription();
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Color: {car.Color}");
                Console.WriteLine($"Body: {car.Body}");
                Console.WriteLine($"Chassis: {car.Chassis}");
                Console.WriteLine($"Dashboard: {car.Dashboard}");
                Console.WriteLine($"Engine: {car.Engine}");
                Console.WriteLine($"Stereosystem: {car.Stereosystem}");
                Console.WriteLine($"Transmission: {car.Transmission}");
                Console.WriteLine("===");
                /* task1.PassengerCar
                   Designed to carry passengers and luggage, with a capacity of 2 to 8 people
                   Model: Mazda
                   Color: Red
                   Body: number = 1, type = open
                   Chassis: type = frame
                   Dashboard: type = electronic
                   Engine: power = 136, cylinders = 1
                   Stereosystem: model = Kenwood Excelon, max sound level = 140
                   Transmission: type = friction
                   ===
                   task1.Truck
                   Designed for the carriage of goods in the body or on a cargo platform
                   Model: Renault
                   Color: Blue
                   Body: number = 2, type = closed
                   Chassis: type = frame
                   Dashboard: type = analogue
                   Engine: power = 136, cylinders = 1
                   Stereosystem: model = Kenwood Excelon, max sound level = 140
                   Transmission: type = friction
                   ===
                 */

            }
        }
    }
}
