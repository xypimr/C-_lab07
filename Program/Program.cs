using Animals;

namespace Program;

class Program
{
    static void Main(string[] args)
    {
        Cow cow = new Cow("RU", "Ivan T");
        Console.WriteLine(cow.GetFavouriteFood());
    }
}