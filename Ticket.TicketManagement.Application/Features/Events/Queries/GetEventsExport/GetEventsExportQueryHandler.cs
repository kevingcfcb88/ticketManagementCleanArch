using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ticket.TicketManagement.Application.Contracts.Infrastructure;
using Ticket.TicketManagement.Application.Contracts.Persistence;
using Ticket.TicketManagement.Domain.Entities;

namespace Ticket.TicketManagement.Application.Features.Events.Queries.GetEventsExport
{
    public class GetEventsExportQueryHandler : IRequestHandler<GetEventsExportQuery, EventExportFileVm>
    {
        private readonly IAsyncRepository<Event> _repository;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetEventsExportQueryHandler(IAsyncRepository<Event> repository, IMapper mapper, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _csvExporter = csvExporter;
            _repository = repository;
        }


        public async Task<EventExportFileVm> Handle(GetEventsExportQuery request, CancellationToken cancellationToken)
        {
            var allElements = _mapper.Map<List<EventExportDto>>((await _repository.ListAllAsync()).OrderBy(e => e.Date));

            var fileData = _csvExporter.ExportEventsToCsv(allElements);

            var eventExportFileDto = new EventExportFileVm()
            {
                ContentType = "text/csv",
                EventExportFileName = $"{Guid.NewGuid()}-export-data.csv",
                Data = fileData
            };

            return eventExportFileDto;
        }
    }
}
