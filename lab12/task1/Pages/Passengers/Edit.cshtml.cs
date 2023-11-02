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
	public class EditModel : PageModel
    {
        private readonly IPassengersRepository passengersRepository;

        public EditModel(IPassengersRepository passengersRepository)
        {
            this.passengersRepository = passengersRepository;
        }

        [BindProperty]
        public Passenger Passenger { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Passenger = passengersRepository.GetPassenger(id.Value);
            } else
            {
                Passenger = new Passenger();
            }

            if (Passenger == null)
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }

        public IActionResult OnPost(Passenger passenger)
        {
            if (Passenger.PassengerId > 0)
            {
                Passenger = passengersRepository.Update(passenger);
            } else
            {
                Passenger = passengersRepository.Add(passenger);
            }
            
            return RedirectToPage("/Passengers/Passengers");
        }
    }
}
