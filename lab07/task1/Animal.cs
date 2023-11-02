using System;
namespace task1
{
	public enum eFavoriteFood
	{
		Meat,
		Plants,
		Everything
	}

    [Comment("Общее животное")]
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

    [Comment("Корова")]
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

    [Comment("Лев")]
    public class Lion : Animal
    {
        public Lion()
        {

        }

        public override eFavoriteFood GetFavoriteFood()
        {
            throw new NotImplementedException();
        }

        public override void SayHello()
        {
            Console.WriteLine("Я лев");
        }
    }

    [Comment("Свинка")]
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

    public class Comment : Attribute
    {
        public string Commentary { get; }
        public Comment()
        {

        }

        public Comment(string comm)
        {
            Commentary = comm;
        }
    }
}

