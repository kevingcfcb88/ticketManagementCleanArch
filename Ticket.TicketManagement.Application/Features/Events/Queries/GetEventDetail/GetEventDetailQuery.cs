using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ticket.TicketManagement.Application.Features.Events
{
    public class GetEventDetailQuery : IRequest<EventDetailVm>
    {
        public Guid Id { get; set; }
    }
}
