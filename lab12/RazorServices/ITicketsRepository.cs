using System;
using RazorModels;

namespace RazorServices
{
	public interface ITicketsRepository
	{
		public IEnumerable<Ticket> GetAllTickets();
        public Ticket? GetTicket(int id);
        public Ticket Add(Ticket ticket);
        public Ticket Update(Ticket uTicket);
        public Ticket Delete(int id);
    }
}

