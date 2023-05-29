
namespace task1
{
    public enum Breed
    {
        Riding, 
        Suffolk,
        Light
    }
    class Horse
    {
        public Breed Breed
        {
            get;
            private set;
        }

        public Color Color
        {
            get;
            private set;
        }
        public int MaxSpeed
        {
            get;
            private set;
        }

        public Horse(Breed breed, Color color, int maxSpeed)
        {
            Breed = breed;
            Color = color;
            MaxSpeed = maxSpeed;
        }

        public string GetCharacteristics()
        {
            return $"breed = {Breed}, color = {Color}, max speed = {MaxSpeed}";
        }

        public static bool operator ==(Horse lhs, Horse rhs)
        {
            return lhs.Breed == rhs.Breed && lhs.MaxSpeed == rhs.MaxSpeed;
        }

        public static bool operator !=(Horse lhs, Horse rhs)
        {
            return !(lhs == rhs);
        }

        public static bool operator <(Horse lhs, Horse rhs)
        {
            return lhs.Breed == rhs.Breed && lhs.MaxSpeed < rhs.MaxSpeed;
        }

        public static bool operator <=(Horse lhs, Horse rhs)
        {
            return lhs.Breed == rhs.Breed && lhs.MaxSpeed <= rhs.MaxSpeed;
        }

        public static bool operator >(Horse lhs, Horse rhs)
        {
            return !(lhs <= rhs);
        }

        public static bool operator >=(Horse lhs, Horse rhs)
        {
            return !(lhs < rhs);
        }
        public static implicit operator Car(Horse horse)
        {
            var breedToType = new Dictionary<Breed, Type>();
            breedToType.Add(Breed.Suffolk, Type.Cargo);
            breedToType.Add(Breed.Light, Type.Passenger);
            breedToType.Add(Breed.Riding, Type.Racing);
            return new Car(breedToType[horse.Breed], horse.Color, horse.MaxSpeed * 3);
        }
    }
}
