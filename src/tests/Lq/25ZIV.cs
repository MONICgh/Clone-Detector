namespace task1
{
    class Transmission
    {
        public string Type { get; private set; }

        public Transmission(string type)
        {
            Type = type;
        }
        public override string ToString()
        {
            return $"type = {Type}";
        }
    }
}
