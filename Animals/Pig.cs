namespace Animals;

[Classification(eClassificationAnimal.Omnivories)]
[Food(eFavouriteFood.Everything)]
[Comment("Class Pig")]
[Serializable]

public class Pig : Animal
{
    public Pig(string country, string name) : base(country, true, name, "Pig"){}

    public override void SayHello()
    {
        Console.WriteLine("Oink-oink`llo!");
    }
}