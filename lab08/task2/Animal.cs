using System;
namespace task12
{
    public enum eFavoriteFood
    {
        Meat,
        Plants,
        Everything
    }

    
    public abstract class Animal
    {
        public string Country { get; set; }
        public bool HideFromOtherAnimals { get; set; }
        public string Name { get; set; }
        public eClassificationAnimal WhatAnimal;

        public enum eClassificationAnimal
        {
            Herbivores,
            Camivores,
            Omnivores
        }

        public Animal()
        {

        }

        public void Deconstruct()
        {

        }

        public eClassificationAnimal GetClassificationAnimal()
        {
            return WhatAnimal;
        }

        public abstract eFavoriteFood GetFavoriteFood();

        public abstract void SayHello();
    }

    [Serializable]
    public class Cow : Animal
    {
        public Cow()
        {

        }

        public override eFavoriteFood GetFavoriteFood()
        {
            throw new NotImplementedException();
        }

        public override void SayHello()
        {
            Console.WriteLine("Муууу");
        }
    }

    [Serializable]
    public class Lion : Animal
    {
        public Lion()
        {

        }

        public Lion(string country, bool hide, string name, eClassificationAnimal classificationAnimal)
        {
            Country = country;
            HideFromOtherAnimals = hide;
            Name = name;
            WhatAnimal = classificationAnimal;
        }

        public override eFavoriteFood GetFavoriteFood()
        {
            throw new NotImplementedException();
        }

        public override void SayHello()
        {
            Console.WriteLine("Я лев");
        }

        public void Show()
        {
            Console.WriteLine($"Lion's name is {Name}, he is from {Country}, " +
                $"he is {WhatAnimal}, and does he hides from animals? {HideFromOtherAnimals}");
        }
    }

    [Serializable]
    public class Pig : Animal
    {
        public Pig()
        {

        }

        public override eFavoriteFood GetFavoriteFood()
        {
            throw new NotImplementedException();
        }

        public override void SayHello()
        {
            Console.WriteLine("Я свин");
        }
    }

}

