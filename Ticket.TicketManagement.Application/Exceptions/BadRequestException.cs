using System;
using System.Collections.Generic;
using System.Text;

namespace Ticket.TicketManagement.Application.Exceptions
{
    class BadRequestException : ApplicationException
    {
        public BadRequestException(string message) : base(message)
        {

        }

    }
}
