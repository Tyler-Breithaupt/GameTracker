using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GameTracker.Data;
using GameTracker.Model;

namespace GameTracker.Pages.VideoGames
{
    public class CreateModel : PageModel
    {
        private readonly GameTracker.Data.GameTrackerContext _context;

        public CreateModel(GameTracker.Data.GameTrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public VideoGame VideoGame { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.VideoGame.Add(VideoGame);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
