using System.Diagnostics;
using System.Reflection;
using Task1;

int Apply(String operation, BlackBox blackBox)
{
    var methodName = operation.Split('(')[0];
    var arg = int.Parse(operation.Split('(')[1].Split(')')[0]);
    blackBox.GetType().GetMethod(methodName, BindingFlags.NonPublic|BindingFlags.Instance, new Type[] {typeof(int)}).Invoke(blackBox, new object?[] { arg });
    return (int) blackBox.GetType().GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(blackBox);
}

BlackBox blackBox = (BlackBox)typeof(BlackBox).GetConstructor(BindingFlags.NonPublic|BindingFlags.Instance, new Type[]{}).Invoke(null);
Debug.Assert(Apply("Add(100)", blackBox) == 100);
Debug.Assert(Apply("Subtract(20)", blackBox) == 80);
Debug.Assert(Apply("Divide(5)", blackBox) == 16);
Debug.Assert(Apply("Multiply(2)", blackBox) == 32);