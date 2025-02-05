using GloboTicket.TicketManagement.Application.Responses;
using MediatR;
using OneOf;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQuery : IRequest<OneOf<EventDetailVm, EventNotFoundResponse>>
    {
        public Guid Id { get; set; }
    }
}
