namespace CarHorse
{
    public class Horse
    {
        public int Weight { get; }
        public string Color { get; }
        public string Name { get; }

        public Horse(int _Weight, string _Color, string _Name)
        {
            Weight = _Weight;
            Color = _Color;
            Name = _Name;
        }

        public static explicit operator Horse(Car car)
        {
            return new Horse(car.Weight, car.Color, car.Name);
        }

        public static bool operator < (Horse horse1, Horse horse2)
        {
            return (horse1.Weight < horse2.Weight) || (horse1.Weight == horse2.Weight && 
                String.Compare(horse1.Name, horse2.Name) < 0);
        }

        public static bool operator > (Horse horse1, Horse horse2)
        {
            return (horse1.Weight > horse2.Weight) || (horse1.Weight == horse2.Weight &&
                String.Compare(horse1.Name, horse2.Name) > 0);
        }

        public static bool operator == (Horse horse1, Horse horse2)
        {
            return horse1.Weight == horse2.Weight && horse1.Color == horse2.Color && 
                horse1.Name == horse2.Name;
        }

        public static bool operator != (Horse horse1, Horse horse2)
        {
            return horse1.Weight != horse2.Weight || horse1.Color != horse2.Color ||
                horse1.Name != horse2.Name;
        }
    }
}
