using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameTracker.Data;
using GameTracker.Model;

namespace GameTracker.Pages.VideoGames
{
    public class DeleteModel : PageModel
    {
        private readonly GameTracker.Data.GameTrackerContext _context;

        public DeleteModel(GameTracker.Data.GameTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VideoGame VideoGame { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videogame = await _context.VideoGame.FirstOrDefaultAsync(m => m.Id == id);

            if (videogame == null)
            {
                return NotFound();
            }
            else
            {
                VideoGame = videogame;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videogame = await _context.VideoGame.FindAsync(id);
            if (videogame != null)
            {
                VideoGame = videogame;
                _context.VideoGame.Remove(VideoGame);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
