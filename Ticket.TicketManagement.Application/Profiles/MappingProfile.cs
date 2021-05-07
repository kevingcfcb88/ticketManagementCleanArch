using AutoMapper;
using System;
using Ticket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using Ticket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using Ticket.TicketManagement.Application.Features.Events;
using Ticket.TicketManagement.Domain.Entities;

namespace Ticket.TicketManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
        }
    }
}
