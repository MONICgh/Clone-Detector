namespace task1
{
    class Cylinder
    {
        public string Metal { get; private set; }
        public int Diameter { get; private set; }

        public Cylinder(string metal, int diameter)
        {
            Metal = metal;
            Diameter = diameter;
        }   
    }
}
