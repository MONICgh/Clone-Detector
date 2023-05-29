using FrogAndLake;

var stones = new List<int> { 1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 };
var lake = new Lake(stones);
foreach (var stone in lake)
{
    Console.Write(stone + " ");
}
Console.WriteLine();

stones = new List<int> { 13 , 23 , 1 , -8 , 4 , 9 };
lake = new Lake(stones);
foreach (var stone in lake)
{
    Console.Write(stone + " ");
}
Console.WriteLine();

stones = new List<int> { 1, 2, 3, 4, 5, 6 };
lake = new Lake(stones);
foreach (var stone in lake)
{
    Console.Write(stone + " ");
}
Console.WriteLine();