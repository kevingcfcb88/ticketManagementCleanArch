using Ticket.TicketManagement.Domain.Entities;
using Ticket.TicketManagement.Application.Contracts.Persistence;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace Ticket.TicketManagement.Persistence.Repositories
{
    class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {

        public CategoryRepository(TicketDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents)
        {
            var categories = await _dbContext.Categories.Include(x => x.Events).ToListAsync();

            if (!includePassedEvents)
            {
                categories.ForEach(p => p.Events.ToList().RemoveAll(c => c.Date < DateTime.Today));
            }

            return categories;
        }
    }
}
