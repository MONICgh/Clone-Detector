using System.Reflection;

namespace task1
{
    class Program
    {
        const BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;
        public static void Main(string[] args)
        {
            Type blackBoxType = typeof(BlackBox);
            ConstructorInfo blackBoxConstructor = blackBoxType.GetConstructor(flags, new Type[] { typeof(int) });
            var blackBox = blackBoxConstructor.Invoke(new object[] { 0 });


            string cmd = Console.ReadLine();
            while (cmd != "end")
            { 
                var splitedCmd = cmd.Split('(', ')');
                string methodName = splitedCmd[0];

                MethodInfo method = blackBoxType.GetMethod(methodName, flags);
                if (method == null)
                {
                    Console.WriteLine($"No such method exists: {methodName}.");
                    continue;
                } 
                else
                {
                    try
                    {
                        int argument = int.Parse(splitedCmd[1]);
                        method.Invoke(blackBox, new object[] { argument });
                        var blackBoxValue = blackBoxType.GetField("innerValue", flags).GetValue(blackBox);
                        Console.WriteLine(blackBoxValue);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Each method takes only one integer number.");
                        Console.WriteLine(e.Message);
                    }
                }
                cmd = Console.ReadLine();
            }
           
            

        }
    }
}
