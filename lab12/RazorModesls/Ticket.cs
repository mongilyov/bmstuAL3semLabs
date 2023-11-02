using System;
namespace RazorModels
{
	public class Ticket
	{
		public int TicketId { get; set; }
		public int PassengerId { get; set; }
		public float Price { get; set; }

		public Ticket()
		{
		}
	}
}

