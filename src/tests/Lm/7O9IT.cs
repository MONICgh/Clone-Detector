using NUnit.Framework;

namespace HW_06.Sparse2D;

public class Test
{
    [Test]
    public void Test1()
    {
        var data = new Sparse1DTable<int>
        {
            [1000000] = 5
        };
        data[2] = data[1000000];

        Assert.AreEqual(new List<int> { 5, 5 }, data.ToList());
    }


    [Test]
    public void Test2()
    {
        var data = new Sparse2DTable<int>();
        data[5][5] = 3;
        data[6][2] = 1;

        var expected = new List<int> { 3, 1 }.ToArray();
        var actual = data.ToArray();
        Assert.AreEqual(expected, actual);
    }

}
