using System;
using RazorModels;

namespace RazorServices
{
	public class SqlTrainsRepository : ITrainsRepository
	{
        private AppDbContext __db;

        public SqlTrainsRepository(AppDbContext db)
		{
            __db = db;
		}

        public Train Add(Train train)
        {
            throw new NotImplementedException();
        }

        public Train Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Train> GetAllTrains()
        {
            throw new NotImplementedException();
        }

        public Train? GetTrain(int id)
        {
            throw new NotImplementedException();
        }

        public Train Update(Train uTrain)
        {
            throw new NotImplementedException();
        }
    }
}

