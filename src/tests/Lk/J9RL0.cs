using System;

namespace Hamsters
{
    public class Hamster : IComparable
    {
        private readonly string _color;
        private readonly int _woolType, _height, _weight, _age;

        public Hamster()
        {
            var rng = new Random();
            string[] possibleColors = { "white", "red", "brown", "black" };
            _color = possibleColors[rng.Next() % 4];
            _woolType = rng.Next(1, 5);
            _weight = rng.Next(25, 65);
            _height = rng.Next(6, 10);
            _age = rng.Next(5, 50);
        }

        public string Color()
        {
            return _color;
        }

        public int WoolType()
        {
            return _woolType;
        }

        public int Weight()
        {
            return _weight;
        }

        public int Height()
        {
            return _height;
        }

        public int Age()
        {
            return _age;
        }

        public int CompareTo(object? obj)
        {
            if (!(obj is Hamster other)) return 1;
            
            if (WoolType() != other.WoolType()) 
                return WoolType().CompareTo(other.WoolType());

            if (Height() != other.Height()) 
                return Height().CompareTo(other.Height());
            
            if (Weight() != other.Weight()) 
                return Weight().CompareTo(other.Weight());

            if (Age() != other.Age())
                return Age().CompareTo(other.Age());

            if (Color() != other.Color()) 
                return Color().CompareTo(other.Color());
            
            return 0;
        }
    }
}