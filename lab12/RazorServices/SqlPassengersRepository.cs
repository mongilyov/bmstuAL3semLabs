using System;
using RazorModels;

namespace RazorServices
{
	public class SqlPassengersRepository : IPassengersRepository
	{
        private AppDbContext __db;

		public SqlPassengersRepository(AppDbContext db)
		{
            __db = db;
		}

        public Passenger Add(Passenger passenger)
        {
            __db.Passengers.Add(passenger);
            __db.SaveChanges();
            return passenger;
        }

        public Passenger Delete(int id)
        {
            var passToDel = __db.Passengers.Find(id);

            if (passToDel != null)
            {
                __db.Passengers.Remove(passToDel);
                __db.SaveChanges();
            }
            return passToDel;
        }

        public IEnumerable<Passenger> GetAllPassengers()
        {
            return __db.Passengers;
        }

        public Passenger? GetPassenger(int id)
        {
            return __db.Passengers.Find(id);
        }

        public Passenger Update(Passenger uPassenger)
        {
            var pass = __db.Passengers.Attach(uPassenger);
            pass.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            __db.SaveChanges();
            return uPassenger;
        }
    }
}

