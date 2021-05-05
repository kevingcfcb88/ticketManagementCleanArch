using System;
using System.Collections.Generic;
using System.Text;
using Ticket.TicketManagement.Domain.Common;

namespace Ticket.TicketManagement.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
