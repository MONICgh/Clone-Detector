
namespace task1
{
    public enum Type
    {
        Cargo,
        Passenger,
        Racing
    }
    class Car
    {
        public Type Type
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

        public Car(Type type, Color color, int maxSpeed)
        {
            Type = type;
            Color = color;
            MaxSpeed = maxSpeed;
        }

        public string GetCharacteristics()
        {
            return $"type = {Type}, color = {Color}, max speed = {MaxSpeed}";
        }

        public static implicit operator Horse(Car car)
        {
            var typeToBreed = new Dictionary<Type, Breed>();
            typeToBreed.Add(Type.Cargo, Breed.Suffolk);
            typeToBreed.Add(Type.Passenger, Breed.Light);
            typeToBreed.Add(Type.Racing, Breed.Riding);
            return new Horse(typeToBreed[car.Type], car.Color, car.MaxSpeed / 3);
        }

        
    }
}
