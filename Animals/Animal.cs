using System.Xml.Serialization;

namespace Animals;

public enum eFavouriteFood
{
    Meat,
    Plants,
    Everything
}

public enum eClassificationAnimal
    {
        Herbivories,
        Carnivories,
        Omnivories
    }

class FoodAttribute : Attribute
{
    public eFavouriteFood _food;
    public FoodAttribute(eFavouriteFood food)
    {
        _food = food;
    }
}

class ClassificationAttribute : Attribute
{
    public eClassificationAnimal _type;
    public ClassificationAttribute(eClassificationAnimal type)
    {
        _type = type;
    }
}

[Comment("Abstract Class")]
[XmlInclude(typeof(Cow))]
[Serializable]
public abstract class Animal
{


    private string _country;
    private bool _hideFromOtherAnimals;
    private string _name;
    private string _whatAnimal;
    public Animal(){}
    public Animal(string country, bool hideFromOtherAnimals, string name, string whatAnimal)
    {
        _country = country;
        this._hideFromOtherAnimals = hideFromOtherAnimals;
        _name = name;
        _whatAnimal = whatAnimal;
    }

    public string WhatAnimal
    {
        get => _whatAnimal;
        set => _whatAnimal = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public bool HideFromOtherAnimals
    {
        get => _hideFromOtherAnimals;
        set => _hideFromOtherAnimals = value;
    }

    public string Country
    {
        get => _country;
        set => _country = value ?? throw new ArgumentNullException(nameof(value));
    }

    public virtual void SayHello()
    {
        Console.WriteLine("Hello!");
    }

    public string GetClassificationAnimal()
    {
        var type = GetType();
        var attributes = type.GetCustomAttributes(false);
        foreach (Attribute attr in attributes)
        {
            if (attr is ClassificationAttribute atrClass)
                return atrClass._type.ToString();
        }

        return "";
    }

    public string GetFavouriteFood()
    {
        var type = GetType();
        var attributes = type.GetCustomAttributes(false);
        foreach (Attribute attr in attributes)
        {
            if (attr is FoodAttribute atrFood)
                return atrFood._food.ToString();
        }

        return "";
    }
}