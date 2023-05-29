using System;
using System.Collections.Generic;

namespace ConversionOperators
{
    public class Horse
    {
        public string Breed;
        public int Age;
        public int Weight;
        public double Height ;
        public bool IsShod;
        public int Speed;
        public string Colour;

        public Horse(string breed, int age, int weight, double height, bool isShod, int speed, string colour)
        {
            Breed = breed;
            Age = age; 
            Weight = weight; 
            Height = height;
            IsShod = isShod;
            Speed = speed;
            Colour = colour;
        }

        public Horse()
        {
            GenerateHorse();
        }

        private void GenerateHorse()
        {
            var rnd = new Random();
            string[] breeds = {"Pony", "Belgian horse", "Thoroughbred"};
            Breed = breeds[rnd.Next(0, breeds.Length)];
            Age = rnd.Next(0, 25);
            Weight = rnd.Next(100, 1000);
            Height = rnd.Next(11, 19) / 10.0;
            IsShod = Convert.ToBoolean(rnd.Next(0, 2));
            Speed = rnd.Next(40, 100);
            string[] colours = {"Red", "Green", "Blue", "Pink", "Orange", "Black", "White"};
            Colour = colours[rnd.Next(0, colours.Length)];
        }

        // если мы знаем, как конвертировать породу в тип машины (пони в легковую, например), мы конвертируем 
        // а если нет, то типом машины просто ставится название породы 
        
        public static implicit operator Car(Horse h)
        {
            var typeHorseCar = new Dictionary<string, string>();
            typeHorseCar.Add("Pony", "Passenger");
            typeHorseCar.Add("Belgian horse", "Cargo");
            typeHorseCar.Add("Thoroughbred", "Racing");
            if (typeHorseCar.ContainsKey(h.Breed))
            {
                return new Car(typeHorseCar[h.Breed], h.Age, h.Weight, h.Height, h.IsShod, h.Speed, h.Colour);
            }
            return new Car(h.Breed, h.Age, h.Weight, h.Height, h.IsShod, h.Speed, h.Colour);
        }
        
        // если мы знаем, как конвертировать тип машины в тпороду (легковую в пони, например), мы конвертируем 
        // а если нет, то породой лошади становится тип машины 
        
        public static implicit operator Horse(Car c)
        {
            var typeHorseCar = new Dictionary<string, string>();
            typeHorseCar.Add("Passenger", "Pony");
            typeHorseCar.Add("Cargo", "Belgian horse");
            typeHorseCar.Add("Racing", "Thoroughbred");
            if (typeHorseCar.ContainsKey(c.Type))
            {
                return new Horse(typeHorseCar[c.Type], c.Age, c.Weight, c.Height, c.IsStudded, c.Speed, c.Colour);
            }
            return new Horse(c.Type, c.Age, c.Weight, c.Height, c.IsStudded, c.Speed, c.Colour);
        }
        
        public static bool operator <(Horse h1, Horse h2)
        {
            if (h1.Age < h2.Age)
            {
                return true;
            }

            if (h1.Weight < h2.Weight)
            {
                return true;
            }

            if (h1.Height < h2.Height)
            {
                return true;
            }
            
            return false;
        }
        
        public static bool operator <=(Horse h1, Horse h2)
        {
            return h1 < h2 || h1.Age == h2.Age && h1.Weight == h2.Weight && h1.Height == h2.Height;
        }
        
        public static bool operator >(Horse h1, Horse h2)
        {
            return !(h1 <= h2);
        }
        
        
        public static bool operator >=(Horse h1, Horse h2)
        {
            return !(h1 < h2);
        }
        
        public static bool operator ==(Horse h1, Horse h2)
        {
            return h1.Breed == h2.Breed && h1.Age == h2.Age && h1.Weight == h2.Weight && h1.Height == h2.Height &&
                h1.IsShod == h2.IsShod && h1.Speed == h2.Speed && h1.Colour == h2.Colour;
        }
        
        public static bool operator !=(Horse h1, Horse h2)
        {
            return !(h1 == h2);
        }
    }

    public class Car
    {
        public string Type;
        public int Age;
        public int Weight;
        public double Height ;
        public bool IsStudded;
        public int Speed;
        public string Colour;
        
        public Car(string type, int age, int weight, double height, bool isStudded, int speed, string colour)
        {
            Type = type;
            Age = age; 
            Weight = weight; 
            Height = height;
            IsStudded = isStudded;
            Speed = speed;
            Colour = colour;
        }
        
        public Car()
        {
            GenerateCar();
        }
        
        private void GenerateCar()
        {
            var rnd = new Random();
            string[] types = {"Passenger", "Cargo", "Racing"};
            Type = types[rnd.Next(0, types.Length)];
            Age = rnd.Next(0, 30);
            Weight = rnd.Next(1000, 1500);
            Height = rnd.Next(15, 17) / 10.0;
            IsStudded = Convert.ToBoolean(rnd.Next(0, 1));
            Speed = rnd.Next(100, 500);
            string[] colours = {"Red", "Green", "Blue", "Pink", "Orange", "Black", "White"};
            Colour = colours[rnd.Next(0, colours.Length)];
        }
    }
}