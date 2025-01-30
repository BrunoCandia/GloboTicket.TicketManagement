using GloboTicket.TicketManagement.Api.Middleware;
using GloboTicket.TicketManagement.Application;
using GloboTicket.TicketManagement.Infraestructure;
using GloboTicket.TicketManagement.Persistence;

namespace GloboTicket.TicketManagement.Api
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureService(this WebApplicationBuilder webApplicationBuilder)
        {
            webApplicationBuilder.Services.AddApplicationServices();
            webApplicationBuilder.Services.AddInfraestructureServices(webApplicationBuilder.Configuration);
            webApplicationBuilder.Services.AddPersistenceServices(webApplicationBuilder.Configuration);

            webApplicationBuilder.Services.AddControllers();

            webApplicationBuilder.Services.AddHttpContextAccessor(); //// se precisa ???

            webApplicationBuilder.Services.AddCors(options =>
            {
                options.AddPolicy(
                    "open",
                    policy => policy.WithOrigins([webApplicationBuilder.Configuration["ApiUrl"] ?? "https://localhost:7020", webApplicationBuilder.Configuration["BlazorUrl"] ?? "http://localhost:7080"])
                        .AllowAnyMethod()
                        .SetIsOriginAllowed(policy => true)
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            webApplicationBuilder.Services.AddSwaggerGen();

            return webApplicationBuilder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication webApplication)
        {
            webApplication.UseCors("open");

            if (webApplication.Environment.IsDevelopment())
            {
                webApplication.UseSwagger();
                webApplication.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "GloboTicket.TicketManagement.Api v1");
                    options.RoutePrefix = string.Empty;
                });
            }

            webApplication.UseMiddleware<ExceptionHandlerMiddleware>();

            webApplication.UseHttpsRedirection();
            webApplication.MapControllers();

            return webApplication;
        }
    }
}
