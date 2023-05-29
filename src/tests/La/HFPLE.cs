using System;
using System.Linq;
using System.Reflection;

internal class Program
{
    private static bool keepRunning = true;
    static void Main(string[] args)
    {
        TypeInfo blackBoxTypeInfo = typeof(BlackBox).GetTypeInfo();
        ConstructorInfo ctor = blackBoxTypeInfo.DeclaredConstructors.First(c => c.GetParameters()[0].ParameterType == Type.GetType("System.Int32"));
        Object blackBox = ctor.Invoke(new Object[] { 1 });

        FieldInfo n = blackBoxTypeInfo.GetDeclaredField("innerValue");

        while (Program.keepRunning)
        {
            string cmd = Console.ReadLine();
            if (cmd.Equals("exit"))
                break;
            int par_1 = cmd.IndexOf('(');
            int par_2 = cmd.IndexOf(')');
            if (par_1 == -1 || par_2 == -1 || par_2 <= par_1 + 1) continue;
            string methodName = cmd.Substring(0, par_1);
            string arg = cmd.Substring(par_1 + 1, par_2 - par_1 - 1);

            MethodInfo mi = blackBoxTypeInfo.GetDeclaredMethod(methodName);
            mi.Invoke(blackBox, new object[] { Convert.ToInt32(arg) });

            Console.WriteLine(n.GetValue(blackBox));
        }
    }
}
