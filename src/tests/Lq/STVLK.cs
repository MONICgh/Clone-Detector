using System.Security.AccessControl;
using System.Text;

namespace Application
{
    class Car: ICloneable
    {
        private int position;
        private int speed;
        private int steps;
        private StringBuilder path = new StringBuilder(); 
        
        public int Position
        {
            get { return position; }
        }
        
        public int Speed
        {
            get { return speed; }
        }
        
        public string Path
        {
            get { return path.ToString(); }
        }
        
        public int Steps
        {
            get { return steps; }
        }

        public Car()
        {
            position = 0;
            speed = 1;
            steps = 0;
        }

        public void A()
        {
            path.Append("A");
            steps++;
            position += speed;
            speed = Math.Abs(speed) * 2;
        }

        public void R()
        {
            path.Append("R");
            steps++;
            if (speed > 0)
            {
                speed = -1;
            }
        }

        public object Clone()
        {
            var car = new Car();
            foreach (var Action in Path)
            {
                if (Action == 'A')
                {
                    car.A();
                }
                else
                {
                    car.R();
                }
            }

            return car;
        }
    }
    
    class Task3
    {
        static string run(int target)
        {
            Car car = new Car();
            Car backCar = null;
            int backAnswer = Int32.MaxValue;
            while (car.Steps <= backAnswer) {
                while (car.Position + car.Speed <= target && car.Steps < backAnswer)
                {
                    car.A();
                    if (car.Position == target)
                    {
                        return car.Path;
                    }
                }

                if (car.Steps >= backAnswer)
                {
                    break;
                }
                
                if (car.Steps + (car.Position + car.Speed - target) * 2 + 1 < backAnswer)
                {
                    backAnswer = car.Steps + (car.Position + car.Speed - target) * 2 + 1;
                    backCar = (Car)car.Clone();
                }
                car.R();
            }

            car = backCar;
            car.A();
            while (car.Position != target)
            {
                car.R();
                car.A();
            }
            return car.Path;
        }
        
        static void Main()
        {
            foreach (var i in new List<int>() { 3, 6, 10, 128, 127, 124, 123 }) 
            {
                Console.WriteLine($"{i}: {run(i)}");
            }
        }
    }
}
