using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ticket.TicketManagement.Application.Features.Events.Queries.GetEventsExport
{
    public class GetEventsExportQuery : IRequest<EventExportFileVm>
    {
    }
}
