using GloboTicket.TicketManagement.Domain.Entities;
using GloboTicket.TicketManagement.Persistence;

namespace GloboTicket.TicketManagement.Initialization.Seeding
{
    public static class Orders
    {
        public static async Task SeedAsync(GloboTicketDbContext globalTicketDbContext)
        {
            Console.WriteLine("Seeding Order...");

            var concertGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var musicalGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var playGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var conferenceGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            var allOrders = new List<Order>
            {
                new Order
                {
                    OrderId = Guid.Parse("{7E94BC5B-71A5-4C8C-BC3B-71BB7976237E}"),
                    OrderTotal = 400,
                    IsOrderPaid = true,
                    OrderPlaced = DateTimeOffset.UtcNow,
                    UserId = Guid.Parse("{A441EB40-9636-4EE6-BE49-A66C5EC1330B}")
                },
                new Order
                {
                    OrderId = Guid.Parse("{86D3A045-B42D-4854-8150-D6A374948B6E}"),
                    OrderTotal = 135,
                    IsOrderPaid = true,
                    OrderPlaced = DateTimeOffset.UtcNow,
                    UserId = Guid.Parse("{AC3CFAF5-34FD-4E4D-BC04-AD1083DDC340}")
                },
                new Order
                {
                    OrderId = Guid.Parse("{771CCA4B-066C-4AC7-B3DF-4D12837FE7E0}"),
                    OrderTotal = 85,
                    IsOrderPaid = true,
                    OrderPlaced = DateTimeOffset.UtcNow,
                    UserId = Guid.Parse("{D97A15FC-0D32-41C6-9DDF-62F0735C4C1C}")
                },
                new Order
                {
                    OrderId = Guid.Parse("{3DCB3EA0-80B1-4781-B5C0-4D85C41E55A6}"),
                    OrderTotal = 245,
                    IsOrderPaid = true,
                    OrderPlaced = DateTimeOffset.UtcNow,
                    UserId = Guid.Parse("{4AD901BE-F447-46DD-BCF7-DBE401AFA203}")
                },
                new Order
                {
                    OrderId = Guid.Parse("{E6A2679C-79A3-4EF1-A478-6F4C91B405B6}"),
                    OrderTotal = 142,
                    IsOrderPaid = true,
                    OrderPlaced = DateTimeOffset.UtcNow,
                    UserId = Guid.Parse("{7AEB2C01-FE8E-4B84-A5BA-330BDF950F5C}")
                },
                new Order
                {
                    OrderId = Guid.Parse("{F5A6A3A0-4227-4973-ABB5-A63FBE725923}"),
                    OrderTotal = 40,
                    IsOrderPaid = true,
                    OrderPlaced = DateTimeOffset.UtcNow,
                    UserId = Guid.Parse("{F5A6A3A0-4227-4973-ABB5-A63FBE725923}")
                },
                new Order
                {
                    OrderId = Guid.Parse("{BA0EB0EF-B69B-46FD-B8E2-41B4178AE7CB}"),
                    OrderTotal = 116,
                    IsOrderPaid = true,
                    OrderPlaced = DateTimeOffset.UtcNow,
                    UserId = Guid.Parse("{7AEB2C01-FE8E-4B84-A5BA-330BDF950F5C}")
                }
            };

            var ordersToAdd = allOrders
                .Where(x => !globalTicketDbContext.Orders.Any(y => y.OrderId == x.OrderId))
                .ToList();

            if (ordersToAdd.Any())
            {
                Console.WriteLine("Adding new orders...");
                await globalTicketDbContext.Orders.AddRangeAsync(ordersToAdd);
                await globalTicketDbContext.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("There are no orders to add.");
            }

            Console.WriteLine("Seeded Order.");
        }
    }
}
