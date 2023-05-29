namespace StructInheritance
{
    public struct Parent
    {
        public string CreateString(string arg)
        {
            return "(Parent)_" + arg + "_(Parent)";
        }

        public int CreateInt(int x)
        {
            return x * x;
        }
    }
}