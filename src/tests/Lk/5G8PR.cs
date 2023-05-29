var hamsters = new List<Hamster>
{
    Hamster.Random(), Hamster.Random(), Hamster.Random(), Hamster.Random(), Hamster.Random(), Hamster.Random(),
    Hamster.Random(), Hamster.Random(), Hamster.Random(), Hamster.Random(), Hamster.Random(), Hamster.Random()
};

Console.WriteLine("Before sorting:");
foreach (var hamster in hamsters)
{
    Console.WriteLine(hamster);
}

hamsters.Sort();

Console.WriteLine("After sorting:");
foreach (var hamster in hamsters)
{
    Console.WriteLine(hamster);
}