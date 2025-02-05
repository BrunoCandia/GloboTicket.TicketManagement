using GloboTicket.TicketManagement.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using OneOf;

namespace GloboTicket.TicketManagement.Api.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        protected IActionResult ProcessError(OneOf<ApiValidationResponse, ApiNotFoundResponse, ApiBadRequestResponse> response)
        {
            var title = "An error occurred";

            return response.Value switch
            {
                ApiValidationResponse validationResponse => BadRequest(new ProblemDetails
                {
                    Title = title,
                    Detail = string.Join(", ", validationResponse.ValdationErrors),
                    Status = StatusCodes.Status400BadRequest,
                    Type = validationResponse.GetType().Name,
                    Instance = HttpContext.Request.Path
                }),
                ApiNotFoundResponse notFoundResponse => NotFound(new ProblemDetails
                {
                    Title = title,
                    Detail = notFoundResponse.Message,
                    Status = StatusCodes.Status404NotFound,
                    Type = notFoundResponse.GetType().Name,
                    Instance = HttpContext.Request.Path
                }),
                ApiBadRequestResponse badRequestResponse => BadRequest(new ProblemDetails
                {
                    Title = title,
                    Detail = badRequestResponse.Message,
                    Status = StatusCodes.Status400BadRequest,
                    Type = badRequestResponse.GetType().Name,
                    Instance = HttpContext.Request.Path
                }),
                _ => throw new NotImplementedException()
            };
        }
    }
}
