using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Horborgs
{
    class Car
    {
        bool is_studded;
        public bool IsStudded { get { return is_studded; } set { is_studded = value; } }
        public enum type
        {
            Moped, Racing, Passenger
        }
        type model; int weight, age, height;
        public type Model { get { return model; } set { model = value; } } 
        public int Weight { get { return weight; } set { weight = value; } }
        public int Age { get { return age; } set { age = value; } }
        public int Height { get { return height; } set { height = value; } }

        public Car(bool is_studded, type model, int weight, int age, int height)
        {
            this.is_studded = is_studded;
            this.model = model;
            this.weight = weight;
            this.age = age;
            this.height = height;
        }

    }
    class Horse
    {
        bool is_shod;
        public enum breed
        {
            American_Quarter, Thoroughbred, Pony
        }
        breed type;
        int weight, age, height;

        public Horse(bool is_shod, breed type, int weight, int age, int height)
        {
            this.is_shod = is_shod;
            this.type = type;
            this.weight = weight;
            this.age = age;
            this.height = height;
        }

        public static implicit operator Horse(Car car)
        {
            breed type = getBreed(car.Model);
            return new Horse(car.IsStudded, type, car.Weight / 5, car.Age, car.Height);
        }

        public static explicit operator Car(Horse horse)
        {
            Car.type model = getType(horse.type);
            return new Car(horse.is_shod, model, horse.weight * 5, horse.age, horse.height);
        }

        public static bool operator >(Horse horse1, Horse horse2) // какой-то способ сравнения
        {
            //Console.WriteLine(150 * horse1.age + 30 * horse1.height + horse1.weight + 1000 * Convert.ToInt32(horse1.is_shod));
            //Console.WriteLine(150 * horse2.age + 30 * horse2.height + horse2.weight + 1000 * Convert.ToInt32(horse2.is_shod));
            if (150 * horse1.age + 30 * horse1.height + horse1.weight + 1000 * Convert.ToInt32(horse1.is_shod) > 
                150 * horse2.age + 30 * horse2.height + horse2.weight + 1000 * Convert.ToInt32(horse2.is_shod) + 10) //вводим погрешность на сравнение, потому что преобразования округляют некоторые параметры
                return true;
            return false;
        }

        public static bool operator <(Horse h1, Horse h2) { return h2 > h1; }

        public static bool operator ==(Horse h1, Horse h2) { return !(h2 > h1) && !(h2 < h1); }

        public static bool operator !=(Horse h1, Horse h2) { return !(h1 == h2); }

        private static Car.type getType(breed type)
        {
            Car.type model;
            switch (type)
            {
                case breed.American_Quarter:
                    model = Car.type.Passenger;
                    break;
                case breed.Thoroughbred:
                    model = Car.type.Racing;
                    break;
                case breed.Pony:
                    model = Car.type.Moped;
                    break;
                default:
                    model = Car.type.Passenger;
                    break;
            }
            return model;
        }

        private static breed getBreed(Car.type model)
        {
            breed type;
            switch (model)
            {
                case Car.type.Passenger:
                    type = breed.American_Quarter;
                    break;
                case Car.type.Racing:
                    type = breed.Thoroughbred;
                    break;
                case Car.type.Moped:
                    type = breed.Pony;
                    break;
                default:
                    type = breed.American_Quarter;
                    break;
            }
            return type;
        }
    }
    class Program
    {
        static string is_more(Horse a, Horse b) //применение перегруженных операторов сравнения
        {
            if (a > b)
            {
                return " > ";
            }
            else if (a < b)
            {
                return " < ";
            }
            else
            {
                return " = ";
            }
        }
        static void Main(string[] args)
        {
            Car car1 = new Car(false, Car.type.Passenger, 1500, 0, 130);
            Horse horse1 = new Horse(true, Horse.breed.American_Quarter, 325, 23, 147);
            Horse horse2 = car1;      // неявное преобразование
            Car car2 = (Car)horse1;   // явное преобразование
            Horse horse3 = car2;      // обратное преобразование

                Console.WriteLine("horse1 " + is_more(horse1,horse2) + " horse2");
                Console.WriteLine("horse1 " + is_more(horse1, horse3) + " horse3"); //убеждаемся в том, что преобразование работает правильно

        }
    }
}