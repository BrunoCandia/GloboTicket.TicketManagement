using GloboTicket.TicketManagement.Domain.Entities;
using GloboTicket.TicketManagement.Persistence;

namespace GloboTicket.TicketManagement.Initialization.Seeding
{
    public static class Categories
    {
        public static async Task SeedAsync(GloboTicketDbContext globalTicketDbContext)
        {
            Console.WriteLine("Seeding Category...");

            var concertGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var musicalGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var playGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var conferenceGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            var allCategories = new List<Category>
            {
                new Category { CategoryId = concertGuid, Name = "Concerts" },
                new Category { CategoryId = musicalGuid, Name = "Musicals" },
                new Category { CategoryId = playGuid, Name = "Plays" },
                new Category { CategoryId = conferenceGuid, Name = "Conferences" }
            };

            var categoriesToAdd = allCategories
                .Where(x => !globalTicketDbContext.Categories.Any(y => y.CategoryId == x.CategoryId))
                .ToList();

            if (categoriesToAdd.Any())
            {
                Console.WriteLine("Adding new categories...");
                await globalTicketDbContext.Categories.AddRangeAsync(categoriesToAdd);
                await globalTicketDbContext.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("There are no categories to add.");
            }

            Console.WriteLine("Seeded Category.");
        }
    }
}
