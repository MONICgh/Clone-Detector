using static Factory.Car;

namespace Factory
{
    class Motor
    {
        private bool HasCylinder;
        public int Power { get; private set; }

        public Motor(int power, bool cyl)
        {
            Power = power;
            HasCylinder = cyl;
        }
    }

    class Car
    {
        public enum Gearbox { auto, manual }

        public int BodyNum { get; private set; }

        private Motor motor; public Gearbox gear;
        public int StereoSistem { get; set; }

        public Car(int bodyNum, int motorPower, bool cyl, Gearbox gear, int stereosistem)
        {
            BodyNum = bodyNum;
            motor = new Motor(motorPower, cyl);
            this.gear = gear;
            StereoSistem = stereosistem;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Car number {BodyNum} with {gear} gearbox");
        }

    }

    class Lexus : Car
    {
        public new Gearbox gear = Gearbox.auto;
        private bool modification;

        public Lexus(int bodyNum, int motorPower, bool cyl, int stereo, bool mod)
            : base(bodyNum, motorPower, cyl, Gearbox.auto, stereo)
        {
            modification = mod;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Car ModelA, number {BodyNum}, {(modification ? "modified" : "w/o modification")}");
        }
    }

    class BMW : Car
    {
        public new Gearbox gear = Gearbox.manual;

        public BMW(int bodyNum, int stereo)
            : base(bodyNum, 100, true, Gearbox.auto, stereo)
        {

        }

        public override void PrintInfo()
        {
            Console.WriteLine($"BMW has number {BodyNum}, stereo {StereoSistem}");
        }
    }

    class Program
    { 
        static void Main(string[] args)
        {
            var cars = new List<Car>();
            cars.Add(new Car(1, 20, false, Gearbox.auto, 3));
            cars.Add(new Lexus(3, 5, false, 3, true));
            cars.Add(new Lexus(5, 67, true, 2, false));
            cars.Add(new BMW(7, 4));
            foreach (var car in cars)
                car.PrintInfo();
        }
    }
}