namespace Cars;

public class Factory
{
    public Car BuildCityCar()
    {
        var countOfCylinders = 8;
        var cylinders = new List<ICylinder>(countOfCylinders);
        for (int i = 0; i < countOfCylinders; i++)
        {
            cylinders.Add(new Cylinder());
        }

        var chassis = new List<IChassis>(4);
        for (int i = 0; i < 4; i++)
        {
            chassis.Add(new CityChassis());
        }
        
        return new Car(
            model: "City car",
            body: new Body(),
            engine: new PetrolEngine(cylinders),
            chassis: chassis,
            transmission: new StandartTransmission(),
            dashboard: new DashBoard(3),
            stereoSystem: new StereoSystem(false, true)
            );
    }
    
    public Car BuildExpensiveCar()
    {

        var chassis = new List<IChassis>(4);
        for (int i = 0; i < 4; i++)
        {
            chassis.Add(new CityChassis(400));
        }
        
        return new Car(
            model: "Expensive car",
            body: new Body(),
            engine: new ElectricEngine(2000),
            chassis: chassis,
            transmission: new StandartTransmission(),
            dashboard: new DashBoard(4),
            stereoSystem: new StereoSystem(true, false)
            );
    }
    
    public Car BuildSportCar()
    {
        var countOfCylinders = 20;
        var cylinders = new List<ICylinder>(countOfCylinders);
        for (int i = 0; i < countOfCylinders; i++)
        {
            cylinders.Add(new SportCylinder());
        }

        var chassis = new List<IChassis>(4);
        for (int i = 0; i < 4; i++)
        {
            chassis.Add(new SportChassis());
        }
        
        return new Car(
            model: "Sport car",
            body: new Body(),
            engine: new PetrolEngine(cylinders),
            chassis: chassis,
            transmission: new SportTransmission(),
            dashboard: new DashBoard(4),
            stereoSystem: new StereoSystem(false, false)
            );
    }
}