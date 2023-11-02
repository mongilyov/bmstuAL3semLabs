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
    public class DeleteModel : PageModel
    {
        private ITrainsRepository __db;
        public DeleteModel(ITrainsRepository db)
        {
            __db = db;
        }

        [BindProperty]
        public Train Train { get; set; }

        public IActionResult OnGet(int id)
        {
            Train = __db.GetTrain(id);
            if (Train == null)
            {
                return RedirectToPage("/Error");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            Train = __db.Delete(Train.TrainId);
            if (Train == null)
            {
                return RedirectToPage("/Error");
            }
            return RedirectToPage("/Tickets/Tickets");
        }
    }
}
