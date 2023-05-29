namespace ImmutableType
{
    public class Point3D
    {
        private int x, y, z;

        public Point3D() { }
        
        public Point3D(int _x, int _y, int _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }
        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public int GetZ()
        {
            return z;
        }

        public Point3D SetX(int _x)
        {
            return new Point3D(_x, y, z);
        }

        public Point3D SetY(int _y)
        {
            return new Point3D(x, _y, z);
        }

        public Point3D SetZ(int _z)
        {
            return new Point3D(x, y, _z);
        }
    }
}