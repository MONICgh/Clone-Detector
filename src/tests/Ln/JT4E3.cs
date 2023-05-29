using NUnit.Framework;

namespace ImmutableType
{
    internal class ImmutableTypeTest
    {
        [Test]
        public void Test1()
        {
            Point3D A = new Point3D();
            Assert.IsTrue(A.GetX() == 0 && A.GetY() == 0 && A.GetZ() == 0);
            Point3D B = A.SetY(1);
            Assert.IsTrue(A.GetX() == 0 && A.GetY() == 0 && A.GetZ() == 0);
            Assert.IsTrue(B.GetX() == 0 && B.GetY() == 1 && B.GetZ() == 0);
            Point3D C = B.SetZ(2);
            Assert.IsTrue(A.GetX() == 0 && A.GetY() == 0 && A.GetZ() == 0);
            Assert.IsTrue(B.GetX() == 0 && B.GetY() == 1 && B.GetZ() == 0);
            Assert.IsTrue(C.GetX() == 0 && C.GetY() == 1 && C.GetZ() == 2);
        }
    }
}
