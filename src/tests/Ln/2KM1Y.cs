using Task4;

var dicesNumber = Convert.ToInt32(Console.ReadLine());
var requiredSum = Convert.ToInt32(Console.ReadLine());
Console.WriteLine(Dices.CountChance(dicesNumber, requiredSum));
