using System;
namespace task1
{
	public class ClassRoom
	{
		private Pupil[] pupils;

		public ClassRoom(params Pupil[] pupils)
		{
			if (pupils.Length != 4)
			{
				throw new DataMisalignedException("Number of pupils must be equal to 4.");
			}
			this.pupils = new Pupil[4];
			pupils.CopyTo(this.pupils, 0);
		}

		public void GetInfo()
		{
			foreach (Pupil pupil in pupils)
			{
				Console.WriteLine(pupil.GetType());
				pupil.Study();
				pupil.Read();
				pupil.Write();
				pupil.Relax();
			}
		}
	}
}

