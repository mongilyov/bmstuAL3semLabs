using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorModels;
using RazorServices;

namespace task1.Pages.Passengers
{
	public class DeleteModel : PageModel
    {
        private IPassengersRepository __db;
        public DeleteModel(IPassengersRepository db)
        {
            __db = db;
        }

        [BindProperty]
        public Passenger Passenger { get; set; }

        public IActionResult OnGet(int id)
        {
            Passenger = __db.GetPassenger(id);
            if (Passenger == null)
            {
                return RedirectToPage("/Error");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            Passenger = __db.Delete(Passenger.PassengerId);
            if (Passenger == null)
            {
                return RedirectToPage("/Error");
            }
            return RedirectToPage("/Passengers/Passengers");
        }
    }
}
