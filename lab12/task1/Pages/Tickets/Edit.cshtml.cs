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
    public class EditModel : PageModel
    {
        private readonly ITicketsRepository ticketsRepository;

        public EditModel(ITicketsRepository ticketsRepository)
        {
            this.ticketsRepository = ticketsRepository;
        }

        [BindProperty]
        public Ticket Ticket { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Ticket = ticketsRepository.GetTicket(id.Value);
            }
            else
            {
                Ticket = new Ticket();
            }

            if (Ticket == null)
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }

        public IActionResult OnPost(Ticket ticket)
        {
            if (Ticket.TicketId > 0)
            {
                Ticket = ticketsRepository.Update(ticket);
            }
            else
            {
                Ticket = ticketsRepository.Add(ticket);
            }

            return RedirectToPage("/Tickets/Tickets");
        }
    }
}
