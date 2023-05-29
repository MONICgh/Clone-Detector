
namespace task1
{
    class CarBody
    {
        public long UniqueNumber { get; private set; }
        public string Type { get; private set; }  

        public CarBody(long uniqueNumber, string type)
        {
            UniqueNumber = uniqueNumber;
            Type = type;
        }

        public override string ToString()
        {
            return $"number = {UniqueNumber}, type = {Type}";
        }
    }
}
