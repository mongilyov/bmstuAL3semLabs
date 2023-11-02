using System;
namespace task1
{
	public abstract class Pupil
	{
		public Pupil()
		{
		}

		public abstract void Study();

		public abstract void Read();

		public abstract void Write();

		public abstract void Relax();

        string name;
	}

	public class ExcellentPupil : Pupil
    { 
		public override void Study()
        { 
            Console.WriteLine("I got an A+ mark today");
		}

        public override void Read()
        {
            Console.WriteLine("I have already read a book");
        }

        public override void Write()
        {
            Console.WriteLine("I have done my homework");
        }

        public override void Relax()
        {
            Console.WriteLine("I have played computer game");
        }
    }

	public class GoodPupil : Pupil
	{
        public override void Study()
        {
            Console.WriteLine("I got B mark today");
        }

        public override void Read()
        {
            Console.WriteLine("I have not read a book yet");
        }

        public override void Write()
        {
            Console.WriteLine("I have done only half of my homework");
        }

        public override void Relax()
        {
            Console.WriteLine("I have been playing computer games for 5 hours straight");
        }
    }

	public class BadPupil : Pupil
	{
        public override void Study()
        {
            Console.WriteLine("I got F mark today");
        }

        public override void Read()
        {
            Console.WriteLine("I don't read books");
        }

        public override void Write()
        {
            Console.WriteLine("I don't know my homework");
        }

        public override void Relax()
        {
            Console.WriteLine("I have played with my friends all day on street");
        }
    }
}

