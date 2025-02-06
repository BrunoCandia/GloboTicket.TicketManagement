using GloboTicket.TicketManagement.Application.Contracts.Identity;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;

namespace GloboTicket.TicketManagement.Persistence.IntegrationTests
{
    public class GloboTicketDbContextTests
    {
        private readonly GloboTicketDbContext _globoTicketDbContext;
        private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
        private readonly string _loggedInUserId;

        public GloboTicketDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<GloboTicketDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            // ILoggedInUserService was added for the purpose of this test but is not used.

            _loggedInUserId = "00000000-0000-0000-0000-000000000000";

            _loggedInUserServiceMock = new Mock<ILoggedInUserService>();

            _loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);

            _globoTicketDbContext = new GloboTicketDbContext(dbContextOptions, null);
        }

        [Fact]
        public async Task Save_SetCreatedByProperty()
        {
            var ev = new Event() { EventId = Guid.NewGuid(), Name = "Test event" };

            await _globoTicketDbContext.Events.AddAsync(ev);

            await _globoTicketDbContext.SaveChangesAsync();

            ev.CreatedBy.ShouldBe("System");
        }
    }
}
