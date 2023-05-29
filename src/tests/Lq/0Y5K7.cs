using Task1;

CarFactory carFactory = new CarFactory();

for (int i = 0; i < 5; i++)
{
    Console.WriteLine("Workday #: " + i);
    foreach (var car in carFactory.Workday())
    {
        Console.WriteLine(car);
    }
}