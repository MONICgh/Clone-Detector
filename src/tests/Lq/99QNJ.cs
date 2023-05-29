namespace task1
{
    internal class Dashboard
    {
        public string Type { get; private set; }

        public Dashboard(string type)
        {
            Type = type;
        }
        public override string ToString()
        {
            return $"type = {Type}";
        }
    }
}
