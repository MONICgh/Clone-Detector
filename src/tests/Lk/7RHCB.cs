using System;

namespace task1
{
    public enum Color
    {
        Gray,
        Red,
        White,
        Black
    }

    class Program
    {
        static void Main(string[] args)
        {
            //implicit conversion
            Horse horse = new Horse(Breed.Riding, Color.Red, 40);
            Car car = horse;
            Console.WriteLine(car.GetCharacteristics()); // type = Racing, color = Red, max speed = 120

            car = new Car(Type.Cargo, Color.Gray, 150);
            //Console.WriteLine(((Horse)car).GetCharacteristics());
            horse = car;
            Console.WriteLine(horse.GetCharacteristics()); // breed = Suffolk, color = Gray, max speed = 50

            //explicit conversion
            Car anotherCar = new Car(Type.Passenger, Color.Gray, 180);
            Console.WriteLine(((Horse)anotherCar).GetCharacteristics()); //breed = Light, color = Gray, max speed = 60

            Horse anotherHorse = new Horse(Breed.Suffolk, Color.Black, 20);
            Console.WriteLine(((Car)anotherHorse).GetCharacteristics()); //type = Cargo, color = Black, max speed = 60


            // Comparison
            Horse horse1 = new Horse(Breed.Light, Color.Black, 80);
            Horse horse2 = new Horse(Breed.Light, Color.Red, 80);
            Horse horse3 = new Horse(Breed.Light, Color.White, 90);

            Console.WriteLine($"horse1 == horse2: {horse1 == horse2}"); //True
            Console.WriteLine($"horse1 != horse2: {horse1 != horse2}"); //False
            Console.WriteLine($"horse1 != horse3: {horse1 != horse3}"); //True
            Console.WriteLine($"horse1 < horse3: {horse1 < horse3}"); //True
            Console.WriteLine($"horse1 <= horse2: {horse1 <= horse2}"); //True
            Console.WriteLine($"horse3 > horse1: {horse3 > horse1}"); //True
            Console.WriteLine($"horse3 >= horse3: {horse3 >= horse3}"); //True
        }
    }
}
