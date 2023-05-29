namespace BlackBox
{
    public class BlackBox
    {
        private int innerValue;
        private BlackBox()
        {
            innerValue = 0;
        }
        private BlackBox(int _innerValue)
        {
            innerValue = _innerValue;
        }

        private void Add(int addend)
        {
            innerValue += addend;
        }
        private void Subtract(int subtrahend)
        {
            innerValue -= subtrahend;
        }
        private void Multiply(int multiplier)
        {
            innerValue *= multiplier;
        }
        private void Divide(int divider)
        {
            innerValue /= divider;
        }
    }
}