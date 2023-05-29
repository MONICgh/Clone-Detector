namespace CarHorse
{
    public class Car
    {
        public int Weight { get; }
        public string Color { get; }
        public string Name { get; }

        public Car(int _Weight, string _Color, string _Name)
        {
            Weight = _Weight;
            Color = _Color;
            Name = _Name;
        }

        public static implicit operator Car(Horse horse)
        {
            return new Car(horse.Weight, horse.Color, horse.Name);
        }
    }
}