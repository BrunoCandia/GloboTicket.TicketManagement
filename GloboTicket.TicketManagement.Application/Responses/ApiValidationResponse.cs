using FluentValidation.Results;

namespace GloboTicket.TicketManagement.Application.Responses
{
    public class ApiValidationResponse
    {
        public List<string> ValdationErrors { get; set; }

        public ApiValidationResponse(ValidationResult validationResult)
        {
            ValdationErrors = new List<string>();

            foreach (var validationError in validationResult.Errors)
            {
                ValdationErrors.Add(validationError.ErrorMessage);
            }
        }
    }
}
