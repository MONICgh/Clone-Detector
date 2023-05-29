using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Application
{
    public class BlackBox
    {
        private int innerValue;
        private BlackBox(int innerValue)
        {
            this.innerValue = innerValue;
        }
        private BlackBox()
        {
            this.innerValue = 0;
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


    class Task1
    {
        static void Main()
        {
            Type blackBoxType = Type.GetType("Application.BlackBox");
            ConstructorInfo blackBoxConstructor = blackBoxType.GetTypeInfo().DeclaredConstructors.First(c => c.GetParameters().Count() == 0);
            object blackBoxObj = blackBoxConstructor.Invoke(null);
            FieldInfo innerValue = blackBoxObj.GetType().GetTypeInfo().GetDeclaredField("innerValue");
            Dictionary<string, MethodInfo> name2method = new Dictionary<string, MethodInfo>();
            Char[] delimiters = { '(', ')' };
            while (true) {
                string operation = Console.ReadLine().Trim();
                var splitted = operation.Split(delimiters);
                if (splitted.Count() == 3 && splitted[2] == "")
                {
                    MethodInfo mi = null;
                    if (name2method.ContainsKey(splitted[0]))
                    {
                        mi = name2method[splitted[0]];
                    }
                    else
                    {
                        mi = blackBoxObj.GetType().GetTypeInfo().GetDeclaredMethod(splitted[0]);
                        if (mi == null)
                        {
                            Console.WriteLine(" -- wrong operation: {0}", splitted[0]);
                            continue;
                        }
                        name2method[splitted[0]] = mi;
                    }
                    int arg = Int32.Parse(splitted[1]); // считаем что можно передать ровно 1 аргумент и он int для простоты
                    object[] args = new object[] { arg };
                    mi.Invoke(blackBoxObj, args);
                    Console.WriteLine("value={0}", innerValue.GetValue(blackBoxObj));
                }
                else
                {
                    Console.WriteLine(" -- wrong operation");
                }
            }
        }
    }
}
