using System;
using RazorModels;

namespace RazorServices
{
	public class MockTicketsRepository : ITicketsRepository
	{
        List<Ticket> __tickets { get; set; }
		public MockTicketsRepository()
		{
            __tickets = new List<Ticket>()
            {
                new Ticket()
                {
                    TicketId = 0,
                    PassengerId = 0,
                    Price = 50
                },
                new Ticket()
                {
                    TicketId = 1,
                    PassengerId = 1,
                    Price = 100
                },
                new Ticket()
                {
                    TicketId = 2,
                    PassengerId = 2,
                    Price = 1000
                }
            };
		}

        public Ticket Add(Ticket ticket)
        {
            ticket.PassengerId = __tickets.Max(x => x.TicketId) + 1;
            __tickets.Add(ticket);
            return ticket;
        }

        public Ticket Delete(int id)
        {
            var ticket = __tickets.FirstOrDefault(p => p.TicketId == id);
            if (ticket != null)
            {
                __tickets.Remove(ticket);
            }
            return ticket;
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return __tickets;
        }

        public Ticket? GetTicket(int id)
        {
            return __tickets.FirstOrDefault(p => p.TicketId == id);
        }

        public Ticket Update(Ticket uTicket)
        {
            Ticket ticket = __tickets.FirstOrDefault(t => t.TicketId == uTicket.TicketId);
            if (ticket != null)
            {
                ticket.Price = uTicket.Price;
            }
            return ticket;
        }
    }
}

