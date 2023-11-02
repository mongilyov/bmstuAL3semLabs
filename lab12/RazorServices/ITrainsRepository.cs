using System;
using RazorModels;

namespace RazorServices
{
	public interface ITrainsRepository
	{
		public IEnumerable<Train> GetAllTrains();
        public Train? GetTrain(int id);
        public Train Add(Train train);
        public Train Update(Train uTrain);
        public Train Delete(int id);
    }
}

