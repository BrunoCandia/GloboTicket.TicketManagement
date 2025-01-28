using CsvHelper;
using GloboTicket.TicketManagement.Application.Contracts.Infraestructure;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventExport;
using System.Globalization;

namespace GloboTicket.TicketManagement.Infraestructure.FileExport
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
                csvWriter.WriteRecords(eventExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}