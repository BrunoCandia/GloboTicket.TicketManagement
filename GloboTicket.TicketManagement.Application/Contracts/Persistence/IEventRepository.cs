using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Contracts.Persistence
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<bool> IsEventNameAndDateUnique(string name, DateTimeOffset eventDate);
    }
}
