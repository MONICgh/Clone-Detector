namespace TrackingAttributes;

[Custom("user1", 3, "Example class with custom attribute", "user2", "user3")]
public class ExampleClass
{
    [Custom("user1", 2, "Example field", "user 3")]
    public int Field;
    
    [Custom("user2", 2, "Method with custom attribute", "user1")]
    public void PublicMethodWithCustomAttribute() {}
    
    public void PublicMethodWithoutCustomAttribute() {}
}