using System.Reflection;

namespace BlackBox
{
    public class WhiteBox
    {
        private object blackBox;
        public WhiteBox()
        {
            Type? blackBoxType = Type.GetType("BlackBox.BlackBox");
            if (blackBoxType == null)
            {
                throw new NotImplementedException("Can't find BlackBox");
            }
            ConstructorInfo? blackBoxConstructor = blackBoxType.GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance, Type.EmptyTypes
            );
            if (blackBoxConstructor == null)
            {
                throw new NotImplementedException("Can't find empty constructor of BlackBox");
            }
            blackBox = blackBoxConstructor.Invoke(Array.Empty<object>());
        }

        public void Add(int addend)
        {
            MethodInfo? addMethod = blackBox.GetType().GetMethod("Add", BindingFlags.NonPublic | BindingFlags.Instance);
            if (addMethod == null)
            {
                throw new NotImplementedException("Can't find method Add in BlackBox");
            }
            addMethod.Invoke(blackBox, new object[] { addend });
        }
        public void Subtract(int subtrahend)
        {
            MethodInfo? subtractMethod = blackBox.GetType().GetMethod("Subtract", BindingFlags.NonPublic | BindingFlags.Instance);
            if (subtractMethod == null)
            {
                throw new NotImplementedException("Can't find method Subtract in BlackBox");
            }
            subtractMethod.Invoke(blackBox, new object[] { subtrahend });
        }
        public void Multiply(int multiplier)
        {
            MethodInfo? multiplyMethod = blackBox.GetType().GetMethod("Multiply", BindingFlags.NonPublic | BindingFlags.Instance);
            if (multiplyMethod == null)
            {
                throw new NotImplementedException("Can't find method Multiply in BlackBox");
            }
            multiplyMethod.Invoke(blackBox, new object[] { multiplier });
        }
        public void Divide(int divider)
        {
            MethodInfo? divideMethod = blackBox.GetType().GetMethod("Divide", BindingFlags.NonPublic | BindingFlags.Instance);
            if (divideMethod == null)
            {
                throw new NotImplementedException("Can't find method Divide in BlackBox");
            }
            divideMethod.Invoke(blackBox, new object[] { divider });
        }

        public void PrintCurrentValue()
        {
            FieldInfo? innerValue = blackBox.GetType().GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);
            if (innerValue == null)
            {
                throw new NotImplementedException("Can't find field innerValue in BlackBox");
            }
            Console.WriteLine(innerValue.GetValue(blackBox));
        }
    }
}
