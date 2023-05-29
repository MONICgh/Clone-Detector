using Xunit;

namespace PasswordGenerator;

public class PasswordGeneratorTest
{
    public static void DoTest()
    {
        var password = PasswordGenerator.Generate();
        Assert.True(password.Length >= 6);
        Assert.True(password.Length <= 20);
        Console.WriteLine(password);
    }
}