using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ticket.TicketManagement.Application.Contracts.Persistence;

namespace Ticket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {

        private readonly IEventRepository _eventRepository;

        public CreateEventCommandValidator(IEventRepository eventRepo)
        {
            _eventRepository = eventRepo;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

            RuleFor(p => p.Date)
                .NotEmpty().WithMessage("{Property Name} is required")
                .NotNull()
                .GreaterThan(DateTime.Now);

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{Property Name} is required")
                .GreaterThan(0);

            RuleFor(e => e)
                .MustAsync(EventNameAndDateUnique)
                .WithMessage($"And event with the same name and date already exists");
        }

        private async Task<bool> EventNameAndDateUnique(CreateEventCommand e, CancellationToken token)
        {
            return !(await _eventRepository.IsEventNameAndDateUnique(e.Name, e.Date));

        }
    }
}
