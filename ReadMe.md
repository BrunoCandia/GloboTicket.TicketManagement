Para ejecutar una migracion sobre Persistence:

Default project: GloboTicket.TicketManagement.Persistence

add-migration MigrationName
update-database

Para bajar la aplicacion:
https://github.com/RicoSuter/NSwag/wiki/nswagstudio

Para ejecutar una migracion sobre Identity:

Default project: GloboTicket.TicketManagement.Identity

add-migration Initial_Identity -StartupProject GloboTicket.TicketManagement.Api -Context GloboTicketIdentityDbContext
update-database -StartupProject GloboTicket.TicketManagement.Api -Context GloboTicketIdentityDbContext