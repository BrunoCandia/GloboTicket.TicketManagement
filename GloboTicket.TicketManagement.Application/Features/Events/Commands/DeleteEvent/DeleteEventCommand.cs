using GloboTicket.TicketManagement.Application.Responses;
using MediatR;
using OneOf;
using OneOf.Types;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand : IRequest<OneOf<Success, EventNotFoundResponse>>
    {
        public Guid EventId { get; set; }
    }
}
