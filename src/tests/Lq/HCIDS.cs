namespace task1
{
    class Engine
    {
        public double Power { get; private set; }
        public List<Cylinder> Cylinders { get; private set; }

        public Engine(double power, List<Cylinder> cylinders)
        {
            Power = power;
            Cylinders = cylinders;
        }
        public override string ToString()
        {
            return $"power = {Power}, cylinders = {Cylinders.Count}";
        }
    }
}
