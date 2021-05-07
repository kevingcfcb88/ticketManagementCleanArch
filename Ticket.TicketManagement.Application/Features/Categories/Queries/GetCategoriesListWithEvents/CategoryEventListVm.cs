using System;
using System.Collections.Generic;
using System.Text;

namespace Ticket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    class CategoryEventListVm
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryEventDto> Events { get; set; }
    }
}
