using System;
using RazorModels;

namespace RazorServices
{
	public class MockTrainsRepository : ITrainsRepository
	{
		List<Train> __trains;

		public MockTrainsRepository()
		{
			__trains = new List<Train>()
			{
				new Train()
				{
					TrainId = 0
				},
				new Train()
				{
					TrainId = 1
				},
				new Train()
				{
					TrainId = 2
				}
			};
		}

        public Train Add(Train train)
        {
            train.TrainId = __trains.Max(x => x.TrainId) + 1;
            __trains.Add(train);
            return train;
        }

        public Train Delete(int id)
        {
            var passenger = __trains.FirstOrDefault(p => p.TrainId == id);
            if (passenger != null)
            {
                __trains.Remove(passenger);
            }
            return passenger;
        }

        public IEnumerable<Train> GetAllTrains()
        {
			return __trains;
        }

        public Train? GetTrain(int id)
        {
            return __trains.FirstOrDefault(p => p.TrainId == id);
        }

        public Train Update(Train uTrain)
        {
            Train train = __trains.FirstOrDefault(p => p.TrainId == uTrain.TrainId);
            if (train != null)
            {
				train.TrainId = uTrain.TrainId;
            }
            return train;
        }
    }
}

