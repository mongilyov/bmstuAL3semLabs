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
	public class PassengersModel : PageModel
    {
        private IPassengersRepository __db;

        public PassengersModel(IPassengersRepository db)
        {
            __db = db;
        }

        public IEnumerable<Passenger> Passengers { get; set; }

        public void OnGet()
        {
            Passengers = __db.GetAllPassengers();
        }
    }
}
