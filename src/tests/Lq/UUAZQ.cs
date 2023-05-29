
namespace task1
{
     class Chassis
    {
        public string Type { get; private set; }

        public Chassis(string type)
        {
            Type = type;
        }
        public override string ToString()
        {
            return $"type = {Type}";
        }
    }
}
