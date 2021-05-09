﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Ticket.TicketManagement.Domain.Entities;

namespace Ticket.TicketManagement.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents);
    }
}
