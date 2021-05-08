using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ticket.TicketManagement.Application.Features.Events.Commands.DeleteEvent
{
    class DeleteEventCommand : IRequest
    {
        public Guid EventId { get; set; }
    }
}
