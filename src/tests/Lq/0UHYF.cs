using CarFactory;

var factory = new CarFactory.CarFactory();
var cars = new List<Car>
{
    factory.BuildCheapCar("Cheap model"),
    factory.BuildMiddleClassCar("Middle class model"),
    factory.BuildHighClassCar("High class model"),
    factory.BuildLuxCar("Lux model"),
};

foreach (var car in cars)
{
    Console.WriteLine(car.ModelName);
}
