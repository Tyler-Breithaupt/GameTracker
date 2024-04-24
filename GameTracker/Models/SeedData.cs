using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using GameTracker.Data;

namespace GameTracker.Model
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GameTrackerContext(
                serviceProvider.GetRequiredService<DbContextOptions<GameTrackerContext>>()))
            {
                // Look for any video games.
                if (context.VideoGame.Any())
                {
                    return;   // DB has been seeded
                }

                context.VideoGame.AddRange(
                    new VideoGame
                    {
                        Title = "The Witcher 3: Wild Hunt",
                        Publisher = "CD Projekt Red",
                        ReleaseDate = DateTime.Parse("2015-05-19"),
                        Rating = 9,
                        Price = 29.99m,
                        Genre = "Action RPG"
                    },
                    new VideoGame
                    {
                        Title = "Grand Theft Auto V",
                        Publisher = "Rockstar Games",
                        ReleaseDate = DateTime.Parse("2013-09-17"),
                        Rating = 9,
                        Price = 19.99m,
                        Genre = "Action-Adventure"
                    },
                    new VideoGame
                    {
                        Title = "The Legend of Zelda: Breath of the Wild",
                        Publisher = "Nintendo",
                        ReleaseDate = DateTime.Parse("2017-03-03"),
                        Rating = 10,
                        Price = 59.99m,
                        Genre = "Action-Adventure"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}