namespace BlackBoxTask;

public class BlackBox
{
    private const int DefaultValue = 0;
    private int innerValue;
    
    private BlackBox(int innerValue)
    {
        this.innerValue = 0;
    }
    private BlackBox()
    {
        this.innerValue = DefaultValue;
    }
    private void Add(int addend)
    {
        this.innerValue += addend;
    }
    private void Subtract(int subtrahend)
    {
        this.innerValue -= subtrahend;
    }
    private void Multiply(int multiplier)
    {
        this.innerValue *= multiplier;
    }
    private void Divide(int divider)
    {
        this.innerValue /= divider;
    }
}