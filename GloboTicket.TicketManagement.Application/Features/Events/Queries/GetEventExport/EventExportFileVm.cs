namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventExport
{
    public class EventExportFileVm
    {
        public string EventExportFileName { get; set; } = null!;
        public string ContentType { get; set; } = null!;
        public byte[] Data { get; set; } = null!;
    }
}