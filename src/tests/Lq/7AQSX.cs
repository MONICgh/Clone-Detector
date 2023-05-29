using Allergies;


var mary = new Allergies.Allergies("Mary");
var joe = new Allergies.Allergies("Joe", 65);
var rob = new Allergies.Allergies("Rob", "Peanuts Chocolate Cats Strawberries");

Console.WriteLine(mary);
Console.WriteLine(joe);
Console.WriteLine(rob);

Console.WriteLine();

Console.WriteLine(mary.IsAllergicTo(Allergen.Eggs));
Console.WriteLine(joe.IsAllergicTo(Allergen.Eggs));
Console.WriteLine(rob.IsAllergicTo(Allergen.Eggs));

Console.WriteLine();

Console.WriteLine(mary.IsAllergicTo("Chocolate"));
Console.WriteLine(joe.IsAllergicTo("Chocolate"));
Console.WriteLine(rob.IsAllergicTo("Chocolate"));

Console.WriteLine();

mary.AddAllergy(Allergen.Shellfish);
mary.AddAllergy("Pollen");
Console.WriteLine(mary);
Console.WriteLine(mary.Score);

Console.WriteLine();

rob.DeleteAllergy(Allergen.Cats);
rob.DeleteAllergy("Peanuts");
rob.DeleteAllergy(Allergen.Eggs);
Console.WriteLine(rob);
Console.WriteLine(rob.Score);
