namespace StructInheritance
{
    public struct Child
    {
        private Parent parent;

        public string CreateString(string arg)
        {
            return parent.CreateString("(Child)_" + arg + "_(Child)");
        }

        public int CreateInt(int x)
        {
            return parent.CreateInt(x);
        }
    }
}
