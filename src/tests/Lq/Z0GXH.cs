namespace Allergies;

[Flags]
public enum Allergen
{
    Empty = 0,
    Eggs = 1,
    Peanut = 2,
    Shellfish = 4,
    Strawberry = 8,
    Tomatoes = 16,
    Chocolate = 32,
    FlowerPollen = 64,
    Cats = 128,
}
