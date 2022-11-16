namespace Animals;

[Classification(eClassificationAnimal.Carnivories)]
[Food(eFavouriteFood.Meat)]
[Comment("Class Lion")]
[Serializable]

public class Lion : Animal
{
    public Lion(string country, string name) : base(country, false, name, "Lion"){}

    public override void SayHello()
    {
        Console.WriteLine("Roar`llo!");
    }
}