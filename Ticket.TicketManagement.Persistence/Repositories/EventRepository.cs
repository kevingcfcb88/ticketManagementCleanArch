using System;
using System.Linq;
using System.Threading.Tasks;
using Ticket.TicketManagement.Application.Contracts.Persistence;
using Ticket.TicketManagement.Domain.Entities;

namespace Ticket.TicketManagement.Persistence.Repositories
{
    class EventRepository : BaseRepository<Event>, IEventRepository
    {

        public EventRepository(TicketDbContext dbContext) : base(dbContext)
        {

        }
        public Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate)
        {
            var matches = _dbContext.Events.Any(e => e.Name.Equals(name) && e.Date.Date.Equals(eventDate.Date));
            return Task.FromResult(matches);
        }
    }
}
