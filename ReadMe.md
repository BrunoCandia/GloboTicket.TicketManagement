# Default Admin User
**Email:** admin_user@gmail.com  
**Password:** `Admin@12345`

# Execute the migration for Persistence:

**Default project:** `GloboTicket.TicketManagement.Persistence`

```sh
add-migration MigrationName
update-database
```

# Execute the migration for Identity:

**Default project:** `GloboTicket.TicketManagement.Identity`

```sh
add-migration Initial_Identity -StartupProject GloboTicket.TicketManagement.Api -Context GloboTicketIdentityDbContext
update-database -StartupProject GloboTicket.TicketManagement.Api -Context GloboTicketIdentityDbContext
```

# Download the app:

[NSwagStudio](https://github.com/RicoSuter/NSwag/wiki/nswagstudio)

# Using OneOf package:

## 1. CreateEventCommandHandler.cs
- This class is responsible for handling the creation of an event.
- It returns `OneOf<Guid, ApiValidationResponse>` to the controller.
- If the creation is successful, it returns the `Guid` of the created event.
- If there are validation errors, it returns an `ApiValidationResponse`.

## 2. EventController.cs
- The `Create` method processes the response from `CreateEventCommandHandler`.
- If errors exist, it returns a `ProblemDetails` object containing the details.
- If the event creation is successful, it returns the `Guid` of the created event.

```sh
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
```

## 3. ServiceClient.cs (Generated with NSwag)
- Located in the UI, this file evaluates the response status code.
- If the status code is `200`, it returns the `Guid`.
- If the status code is `400`, it throws an `ApiException`, passing the `ProblemDetails` object.

## 4. EventDataService.cs
- Catches the `ApiException` thrown by `ServiceClient`.
- Calls `ConvertApiExceptions` to handle the error appropriately.

## 5. BaseDataService.cs
- Handles different exceptions based on the status code.
- Implements logic to manage various API errors effectively.