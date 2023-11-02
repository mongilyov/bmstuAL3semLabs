using System;
using RazorModels;

namespace RazorServices
{
	public class SqlTicketsRepository : ITicketsRepository
	{
        private AppDbContext __db;

        public SqlTicketsRepository(AppDbContext db)
		{
            __db = db;
		}

        public Ticket Add(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Ticket Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            throw new NotImplementedException();
        }

        public Ticket? GetTicket(int id)
        {
            throw new NotImplementedException();
        }

        public Ticket Update(Ticket uTicket)
        {
            throw new NotImplementedException();
        }
    }
}

