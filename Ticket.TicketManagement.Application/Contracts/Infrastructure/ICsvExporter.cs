using System.Collections.Generic;
using Ticket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;

namespace Ticket.TicketManagement.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
    }
}
