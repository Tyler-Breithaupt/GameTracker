using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GameTracker.Model;

namespace GameTracker.Data
{
    public class GameTrackerContext : DbContext
    {
        public GameTrackerContext (DbContextOptions<GameTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<GameTracker.Model.VideoGame> VideoGame { get; set; } = default!;
    }
}
