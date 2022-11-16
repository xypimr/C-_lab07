namespace Animals;

[Classification(eClassificationAnimal.Herbivories)]
[Food(eFavouriteFood.Plants)]
[Comment("Class Cow")]
[Serializable]

public class Cow : Animal
{
    public Cow():base(){}
    public Cow(string country, string name):base(country, false, name, "Cow"){}
    
    public override void SayHello()
    {
        Console.WriteLine("Muuuu`llo");
    }
}