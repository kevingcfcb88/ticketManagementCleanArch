using System;
using System.Collections.Generic;
using System.Text;

namespace Ticket.TicketManagement.Application.Features.Events
{
    public class EventListVm
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string IageUrl { get; set; }

    }
}
