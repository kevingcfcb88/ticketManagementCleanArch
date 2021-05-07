using MediatR;
using System.Collections.Generic;

namespace Ticket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    class GetCategoriesListWithEventsQuery : IRequest<List<CategoryEventListVm>>
    {
        public bool IncludeHistory { get; set; }
    }
}
