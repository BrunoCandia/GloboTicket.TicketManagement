using GloboTicket.TicketManagement.Api;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up API");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(
    configureLogger: (context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
        .WriteTo.Console(),
    preserveStaticLogger: true);

var app = builder.ConfigureService()
                 .ConfigurePipeline();

app.UseSerilogRequestLogging();

await app.RunAsync();
