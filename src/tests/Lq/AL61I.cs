namespace HW_12.car_factory;

public class Factory
{
    private int _lastBodyNumber;

    public Car GetCar(IBody givenBody, IPanel givenPanel, IStereoSystem givenSystem)
    {
        return new Car(givenBody.WithNumber(++_lastBodyNumber), new UsualEngine(),
            new UsualWheels(), new UsualTransmission(), givenPanel, givenSystem);
    }
}
