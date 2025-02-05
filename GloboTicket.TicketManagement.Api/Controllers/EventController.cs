using GloboTicket.TicketManagement.Api.Utility;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.DeleteEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventExport;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.TicketManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllEvents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<EventListVm>>> GetAllEvents()
        {
            var result = await _mediator.Send(new GetEventsListQuery());

            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetEventById")]
        [ProducesResponseType(typeof(EventDetailVm), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEventById(Guid id)
        {
            var getEventDetailQuery = new GetEventDetailQuery() { Id = id };
            var result = await _mediator.Send(getEventDetailQuery);

            return result.Match<IActionResult>(
                eventDetailVm => Ok(eventDetailVm),
                notFoundError => ProcessError(notFoundError)
            );
        }

        [HttpPost(Name = "AddEvent")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateEventCommand createEventCommand)
        {
            var result = await _mediator.Send(createEventCommand);

            return result.Match<IActionResult>(
                guid => Ok(guid),
                validationError => ProcessError(validationError)
            );
        }

        [HttpPut(Name = "UpdateEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromBody] UpdateEventCommand updateEventCommand)
        {
            var result = await _mediator.Send(updateEventCommand);

            return result.Match<IActionResult>(
                success => NoContent(),
                notFoundError => ProcessError(notFoundError),
                validationError => ProcessError(validationError)
            );
        }

        [HttpDelete("{id}", Name = "DeleteEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteEventCommand = new DeleteEventCommand() { EventId = id };
            var result = await _mediator.Send(deleteEventCommand);

            return result.Match<IActionResult>(
                success => NoContent(),
                notFoundError => ProcessError(notFoundError)
            );
        }

        [HttpGet("export", Name = "ExportEvents")]
        [FileResultContentType("text/csv")]
        public async Task<FileResult> ExportEvents()
        {
            var fileDto = await _mediator.Send(new GetEventExportQuery());

            return File(fileDto.Data, fileDto.ContentType, fileDto.EventExportFileName);
        }
    }
}
