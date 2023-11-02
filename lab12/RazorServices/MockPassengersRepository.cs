using System;
using RazorModels;

namespace RazorServices
{
	public class MockPassengersRepository : IPassengersRepository
	{
        private List<Passenger> __passengers;

		public MockPassengersRepository()
		{
            __passengers = new List<Passenger>()
            {
                new Passenger()
                {
                    PassengerId = 0,
                    Name = "Andrew",
                    Email = "abc@www.com"
                },
                new Passenger()
                {
                    PassengerId = 1,
                    Name = "Alice",
                    Email = "alice@alice.com"
                },
                new Passenger()
                {
                    PassengerId = 2,
                    Name = "Vova",
                    Email = "vova@vova.com"
                }
            };
		}

        public Passenger Add(Passenger passenger)
        {
            passenger.PassengerId = __passengers.Max(x => x.PassengerId) + 1;
            __passengers.Add(passenger);
            return passenger;
        }

        public Passenger Delete(int id)
        {
            var passenger = __passengers.FirstOrDefault(p => p.PassengerId == id);
            if (passenger != null)
            {
                __passengers.Remove(passenger);
            }
            return passenger;
        }

        public IEnumerable<Passenger> GetAllPassengers()
        {
            return __passengers;
        }

        public Passenger? GetPassenger(int id)
        {
            return __passengers.FirstOrDefault(p => p.PassengerId == id);
        }

        public Passenger Update(Passenger uPassenger)
        {
            Passenger pass = __passengers.FirstOrDefault(p => p.PassengerId == uPassenger.PassengerId);
            if (pass != null)
            {
                pass.Name = uPassenger.Name;
                pass.Email = uPassenger.Email;
            }
            return pass;
        }
    }
}

