namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventExport
{
    public class EventExportDto
    {
        public Guid EventId { get; set; }
        public string Name { get; set; } = null!;
        public DateTimeOffset Date { get; set; }
    }
}