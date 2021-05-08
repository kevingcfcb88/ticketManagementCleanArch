using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ticket.TicketManagement.Application.Exceptions
{
    class ValidationException : ApplicationException
    {
        public List<string> ValidationErrors { get; set; }

        public ValidationException(ValidationResult validationResult)
        {
            ValidationErrors = new List<string>();

            foreach (var validation in validationResult.Errors)
            {
                ValidationErrors.Add(validation.ErrorMessage);
            }

        }
    }
}
