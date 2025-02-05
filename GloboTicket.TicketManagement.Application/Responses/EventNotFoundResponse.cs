namespace GloboTicket.TicketManagement.Application.Responses
{
    public class EventNotFoundResponse : ApiNotFoundResponse
    {
        public EventNotFoundResponse(Guid id) : base($"Event with id: {id} was not found in database.")
        {
        }
    }
}
