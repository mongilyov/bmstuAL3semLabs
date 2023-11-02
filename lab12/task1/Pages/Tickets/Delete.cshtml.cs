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
    public class DeleteModel : PageModel
    {
        private ITicketsRepository __db;
        public DeleteModel(ITicketsRepository db)
        {
            __db = db;
        }

        [BindProperty]
        public Ticket Ticket { get; set; }

        public IActionResult OnGet(int id)
        {
            Ticket = __db.GetTicket(id);
            if (Ticket == null)
            {
                return RedirectToPage("/Error");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            Ticket = __db.Delete(Ticket.TicketId);
            if (Ticket == null)
            {
                return RedirectToPage("/Error");
            }
            return RedirectToPage("/Tickets/Tickets");
        }
    }
}
