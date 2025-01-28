using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Contracts.Persistence
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<List<Order>> GetPagedOrdersForMonthAsync(DateTimeOffset date, int page, int size);
        Task<int> GetTotalCountOfOrdersForMonthAsync(DateTimeOffset date);
    }
}
