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

# Architecture Tests using ArchUnitNET

-**Layered Rules**: Enforces separation of concerns.
-**Naming Rules**: Ensures consistency across the codebase.
-**Dependency Rules**: Prevents tight coupling and circular references.

For reference, https://youtu.be/-vC-E6tAMNs