using BlackBox;
using BindingFlags = System.Reflection.BindingFlags;

const string innerValueFieldName = "innerValue";
const BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;

var blackBoxType = typeof(BlackBox.BlackBox);
var blackBoxEntity = blackBoxType
    .GetConstructor(flags, null, new[] { typeof(int) }, null)!
    .Invoke(new object[] { 0 });

while (true)
{
    try
    {
        var operation = new Operation(Console.ReadLine()!);
        var blackBoxMethod = blackBoxType.GetMethod(operation.methodName, flags);

        if (blackBoxMethod == null)
        {
            throw new ArgumentException("Invalid operation name!");
        }
        
        blackBoxMethod.Invoke(blackBoxEntity, new object[] { operation.argument });
        var result = blackBoxType
            .GetField(innerValueFieldName, flags)!
            .GetValue(blackBoxEntity);
    
        Console.WriteLine(result);
    }
    catch (ArgumentException exception)
    {
        Console.WriteLine(exception.Message);
    }
}