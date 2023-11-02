using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorModels;
using RazorServices;

namespace task1.Pages.Tickets
{
	public class TicketsModel : PageModel
    {
        private ITicketsRepository __db;

        public TicketsModel(ITicketsRepository db)
        {
            __db = db;
        }

        public IEnumerable<Ticket> Tickets { get; set; }

        public void OnGet()
        {
            Tickets = __db.GetAllTickets();
        }
    }
}
