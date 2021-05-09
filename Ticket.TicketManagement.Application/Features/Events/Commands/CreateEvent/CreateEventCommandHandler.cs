using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ticket.TicketManagement.Application.Contracts.Infrastructure;
using Ticket.TicketManagement.Application.Contracts.Persistence;
using Ticket.TicketManagement.Application.Models.Mail;
using Ticket.TicketManagement.Domain.Entities;

namespace Ticket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _email;

        public CreateEventCommandHandler(IEventRepository eventRepo, IMapper mapper, IEmailService email)
        {
            _mapper = mapper;
            _eventRepository = eventRepo;
            _email = email;
        }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEventCommandValidator(_eventRepository);

            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new Exceptions.ValidationException(validationResult);
            }

            var @event = _mapper.Map<Event>(request);

            @event = await _eventRepository.AddAsync(@event);

            var email = new Email()
            {
                To = "email@email.com",
                Body = $"Event: {@event.Name} has been created",
                Subject = "New Event"
            };

            try
            {
                await _email.SendEmail(email);
            }
            catch (Exception ex)
            {
                //
            }

            return @event.EventId;
        }
    }
}
