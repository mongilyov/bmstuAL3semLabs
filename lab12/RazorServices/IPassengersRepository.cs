using System;
using RazorModels;

namespace RazorServices
{
    public interface IPassengersRepository
    {
        public IEnumerable<Passenger> GetAllPassengers();
        public Passenger? GetPassenger(int id);
        public Passenger Add(Passenger passenger);
        public Passenger Update(Passenger uPassenger);
        public Passenger Delete(int id);
    }
}

