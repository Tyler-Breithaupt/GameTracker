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
    public class IndexModel : PageModel
    {
        private readonly GameTracker.Data.GameTrackerContext _context;

        public IndexModel(GameTracker.Data.GameTrackerContext context)
        {
            _context = context;
        }

        public IList<VideoGame> VideoGame { get;set; } = default!;

        public async Task OnGetAsync()
        {
            VideoGame = await _context.VideoGame.ToListAsync();
        }
    }
}
