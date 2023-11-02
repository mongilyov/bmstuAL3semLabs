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
    public class EditModel : PageModel
    {
        private readonly ITrainsRepository trainsRepository;

        public EditModel(ITrainsRepository trainsRepository)
        {
            this.trainsRepository = trainsRepository;
        }

        [BindProperty]
        public Train Train { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Train = trainsRepository.GetTrain(id.Value);
            }
            else
            {
                Train = new Train();
            }

            if (Train == null)
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }

        public IActionResult OnPost(Train train)
        {
            if (Train.TrainId > 0)
            {
                Train = trainsRepository.Update(train);
            }
            else
            {
                Train = trainsRepository.Add(train);
            }

            return RedirectToPage("/Trains/Trains");
        }
    }
}
