namespace GloboTicket.TicketManagement.Application.Responses
{
    public abstract class ApiNotFoundResponse
    {
        public string Message { get; set; }

        protected ApiNotFoundResponse(string message)
        {
            Message = message;
        }
    }
}
