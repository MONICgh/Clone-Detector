namespace HamsterSort
{
    public class Hamster : IComparable<Hamster>
    {
        private int age;
        private int weight;
        private int height;

        public Hamster(int _age, int _weight, int _height)
        {
            age = _age;
            weight = _weight;
            height = _height;
        }

        public int Value()
        {
            return age * age + 5 * weight - 3 * height;
        }

        public int CompareTo(Hamster? other)
        {
            if (other == null)
            {
                return 1;
            }
            return Value() - other.Value(); 
        }
    }
}