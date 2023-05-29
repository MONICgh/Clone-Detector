using AllergiesTask;

var allergies = new Allergies("Bob");
Console.WriteLine(allergies.ToString());
allergies.AddAllergy("Shellfish");
Console.WriteLine(allergies.ToString());
allergies.AddAllergy(Allergen.Chocolate);
allergies.AddAllergy(Allergen.Pollen);
Console.WriteLine(allergies.ToString());
allergies.DeleteAllergy("Chocolate");
Console.WriteLine(allergies.ToString());

allergies = new Allergies("Mary", 158);
Console.WriteLine(allergies.ToString());

allergies = new Allergies("Alex", "Pollen Strawberries Eggs");
Console.WriteLine(allergies.ToString());
allergies.DeleteAllergy(Allergen.Cats);
Console.WriteLine(allergies.ToString());