using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorModels;
using RazorServices;

namespace task1.Pages.Trains
{
	public class TrainsModel : PageModel
    {
        private ITrainsRepository __db;

        public TrainsModel(ITrainsRepository db)
        {
            __db = db;
        }

        public IEnumerable<Train> Trains { get; set; }

        public void OnGet()
        {
            Trains = __db.GetAllTrains();
        }
    }
}
