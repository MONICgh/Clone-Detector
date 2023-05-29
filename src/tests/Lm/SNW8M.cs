using SparseMatrix;

var matrix = new SparseMatrix<int>();
Random r = new Random();
var maxInt = 10000000;

for (var i = 0; i < 100; i++)
{
    var x = r.Next(0, maxInt);
    var y = r.Next(0, maxInt);
    var z = r.Next(0, maxInt);

    matrix[x, y, z] = r.Next(0, 1000);
}

foreach (var item in matrix)
{
    Console.WriteLine("matrix[" + item.X + ", " + item.Y + ", " + item.Z + "] = " + item.value);
}