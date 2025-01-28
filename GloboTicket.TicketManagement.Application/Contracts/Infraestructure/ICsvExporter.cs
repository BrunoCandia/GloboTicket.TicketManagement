using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventExport;

namespace GloboTicket.TicketManagement.Application.Contracts.Infraestructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
    }
}
